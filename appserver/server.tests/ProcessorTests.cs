using Moq;
using System.Collections.Concurrent;

namespace AppServer.Commands.Tests
{
    public class ProcessorTests
    {
        public ProcessorTests()
        {
            new Scopes.InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void HardStopCommand_Should_Stop_Processor_Immediately()
        {
            Dictionary<string, object> processorContext = new Dictionary<string, object>();
            new InitProcessorContextCommand(processorContext).Execute();

            var queue = (BlockingCollection<ICommand>)processorContext["queue"];

            queue.Add(new Mock<ICommand>().Object);
            queue.Add(new HardStopCommand(processorContext));
            queue.Add(new Mock<ICommand>().Object);

            var processor = new Processor(new Processable(processorContext));

            Assert.True(processor.Wait(5000));

            Assert.Single(queue);
        }

        [Fact]
        public void SoftStopCommand_Should_Stop_Processor_When_Queue_Is_Empty()
        {
            Dictionary<string, object> processorContext = new Dictionary<string, object>();
            new InitProcessorContextCommand(processorContext).Execute();

            var queue = (BlockingCollection<ICommand>)processorContext["queue"];

            queue.Add(new Mock<ICommand>().Object);
            queue.Add(new SoftStopCommand(processorContext));
            queue.Add(new Mock<ICommand>().Object);

            var processor = new Processor(new Processable(processorContext));

            Assert.True(processor.Wait(5000));

            Assert.Empty(queue);
        }

        [Fact]
        public void Processor_Should_Be_Stoped_If_Processable_Can_Not_Handle_Exception()
        {
            Dictionary<string, object> processorContext = new Dictionary<string, object>();
            new InitProcessorContextCommand(processorContext).Execute();

            var queue = (BlockingCollection<ICommand>)processorContext["queue"];

            var cmd = new Mock<ICommand>();
            cmd.Setup(x => x.Execute()).Throws<Exception>().Verifiable();
            queue.Add(cmd.Object);

            var processor = new Processor(new Processable(processorContext));

            Assert.True(processor.Wait(5000));
            Assert.True(processorContext.ContainsKey("terminateException"));
            cmd.VerifyAll();
        }

        [Fact]
        public void Processor_Can_Be_Continued_If_Processable_Can_Handle_Exception()
        {
            Dictionary<string, object> processorContext = new Dictionary<string, object>();
            new InitProcessorContextCommand(processorContext).Execute();

            bool exceptionWasHandled = false;

            var queue = (BlockingCollection<ICommand>)processorContext["queue"];
            processorContext["exceptionHandler"] = (ICommand cmd, Exception ex) =>
            {
                exceptionWasHandled = true;
            };

            var cmd = new Mock<ICommand>();
            cmd.Setup(x => x.Execute()).Throws<Exception>().Verifiable();
            queue.Add(cmd.Object);
            queue.Add(new HardStopCommand(processorContext));

            var processor = new Processor(new Processable(processorContext));

            Assert.True(processor.Wait(5000));
            Assert.True(exceptionWasHandled);
            cmd.VerifyAll();
        }

        [Fact]
        public void Prcocessor_Can_Be_Created_By_Server_CommandProcessor_Dependency()
        {
            new RegisterProcessorCommand().Execute();

            var processorContext = Ioc.Resolve<IDictionary<string, object>>("Server.CommandProcessor");
            var processor = (Processor)processorContext["processor"];

            var queue = (BlockingCollection<ICommand>)processorContext["queue"];

            queue.Add(new HardStopCommand(processorContext));

            Assert.True(processor.Wait(5000));
        }
    }
}
