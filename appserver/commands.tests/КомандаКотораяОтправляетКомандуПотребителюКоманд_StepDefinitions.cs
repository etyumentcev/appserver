using Moq;
using System;
using System.Windows.Input;
using TechTalk.SpecFlow;

namespace App.Commands
{
    [Binding]
    public class КомандаКотораяОтправляетКомандуПотребителюКоманд_StepDefinitions
    {
        ICommand _testedCmd;
        Exception? _ex = null;
        Mock<ICommand> sendingCmd = new Mock<ICommand>();

        Mock<ICommandConsumer> _commamdConsumer = new Mock<ICommandConsumer>();

        [Given(@"Команда Send")]
        public void GivenКомандаSend()
        {
            var sendingCmdInstance = sendingCmd.Object;
            _commamdConsumer.Setup(consumer => consumer.Receive(It.Is<ICommand>(c => c == sendingCmdInstance))).Verifiable();

            _testedCmd = new SendCommand(sendingCmdInstance, _commamdConsumer.Object);
        }

        [When(@"Команда Send выполняется")]
        public void WhenКомандаSendВыполняется()
        {
            try
            {
                _testedCmd.Execute();
            }
            catch (Exception ex) 
            { 
                _ex = ex;
            }
        }

        [Then(@"Команда переданная в Send в конструкторе передается в потребитель команд")]
        public void ThenКомандаПереданнаяВSendВКонструктореПередаетсяВПотребительКоманд()
        {
            _commamdConsumer.VerifyAll();
        }

        [Given(@"Потребитель команд выбрасывает исключение")]
        public void GivenПотребительКомандВыбрасываетИсключение()
        {
            var sendingCmdInstance = sendingCmd.Object;
            _commamdConsumer
                .Setup(consumer => consumer.Receive(It.Is<ICommand>(c => c == sendingCmdInstance)))
                .Throws<Exception>()
                .Verifiable();
        }

        [Then(@"Команда Send прерывается выбросом исключения")]
        public void ThenКомандаSendПрерываетсяВыбросомИсключения()
        {
            Assert.NotNull(_ex);
        }

    }
}
