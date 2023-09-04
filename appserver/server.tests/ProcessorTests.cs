using Moq;
using System.Collections.Concurrent;

namespace AppServer.Commands.Tests
{
    public class ProcessorTests
    {
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
    }
}
