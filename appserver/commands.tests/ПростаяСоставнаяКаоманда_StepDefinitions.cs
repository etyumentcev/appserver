using Moq;
using System;
using System.Windows.Input;
using TechTalk.SpecFlow;

namespace AppServer.Commands.Tests
{
    [Binding]
    public class ПростаяСоставнаяКаоманда_StepDefinitions
    {
        ICommand? _cmd;
        Mock<ICommand>[]? _cmds;
        Exception? _ex;

        private Mock<ICommand> CreateMockForICOmmand()
        {
            var c = new Mock<ICommand>();
            c.Setup(c => c.Execute()).Verifiable();
            return c;
        }

        private Mock<ICommand> CreateMockForICOmmandWhichThrowException()
        {
            var c = new Mock<ICommand>();
            c.Setup(c => c.Execute()).Throws<Exception>().Verifiable();
            return c;
        }

        [Given(@"макрокоманда, собранная из последовательности команд")]
        public void GivenМакрокомандаСобраннаяИзПоследовательностиКоманда()
        {

            _cmds = new Mock<ICommand>[]
            {
                CreateMockForICOmmand(),
                CreateMockForICOmmand(),
                CreateMockForICOmmand()
            };

            _cmd = new SimpleMacroCommand(_cmds.Select((m => m.Object)));
        }

        [When(@"макрокоманда выполняется")]
        public void WhenМакрокомандаВыполняется()
        {
            try
            {
                _cmd!.Execute();
            }
            catch (Exception ex) 
            {
                _ex = ex;
            }
        }

        [Then(@"выполняются все команды последовательности\.")]
        public void ThenВыполняютсяВсеКомандыПоследовательности_()
        {
            Array.ForEach(_cmds!, m => m.VerifyAll());
            Assert.Null(_ex);
        }

        [Given(@"макрокоманда, собранная из последовательности команд, одна из которых выбрасвает исключение")]
        public void GivenМакрокомандаСобраннаяИзПоследовательностиКомандОднаИзКоторыхВыбрасваетИсключение()
        {
            _cmds = new Mock<ICommand>[]
            {
                CreateMockForICOmmand(),
                CreateMockForICOmmandWhichThrowException(),
                CreateMockForICOmmand()
            };

            _cmd = new SimpleMacroCommand(_cmds.Select((m => m.Object)));
        }

        [Then(@"макрокоманда прервывается выброшенным исключением\.")]
        public void ThenМакрокомандаПрервываетсяВыброшеннымИсключением_()
        {
            _cmds![0].VerifyAll();
            _cmds![1].VerifyAll();
            _cmds![2].VerifyNoOtherCalls();

            Assert.NotNull(_ex);
        }

    }
}
