using Moq;
using SpaceBattle;

using Game;
using AppServer;

namespace Game.Tests.StepDefinitions
{
    [Binding]
    public class МожноОтдаватьПриказыНаВыпронениеОперацийStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        Mock<IApplyActionOrder> _order = new Mock<IApplyActionOrder>();
        Mock<ICommand> _cmdMock = new Mock<ICommand>();
        ICommand  _cmd;
        Mock<ICommandReceiver> _receiverMock = new Mock<ICommandReceiver>();
        ICommandReceiver _receiver;
        Exception? _ex = null;


        public МожноОтдаватьПриказыНаВыпронениеОперацийStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _cmd = _cmdMock.Object;
            _receiver = _receiverMock.Object;
            
        }

        [Given(@"Приказ на выполнение операции")]
        public void ДопустимПриказНаВыполнениеОперации()
        {
            _order.SetupGet<ICommand>(
                o => o.Command
            )
            .Returns(_cmd)
            .Verifiable();

            _order.SetupGet<ICommandReceiver>(
                o => o.Target
            )
            .Returns(_receiver)
            .Verifiable();
        }
        
        [When(@"Исполняется приказ")]
        public void КогдаИсполняетсяПриказ()
        {
            try
            {
                new ApplyActionOrderCommand(_order.Object).Execute();
            }
            catch(Exception ex)
            {
                _ex = ex;
            }
        }

        [Given(@"Приказ, из которого не удается получить операцию")]
        public void ДопустимПриказИзКоторогоНеУдаетсяПолучитьОперацию()
        {
            _order.SetupGet<ICommand>(
                o => o.Command
            )
            .Throws<Exception>()
            .Verifiable();
        }

        [Given(@"Приказ, из которого не удается определить исполнителя")]
         public void ДопустимПриказИзКоторогоНеУдаетсяОпределитьИсполнителя()
         {
             _order.SetupGet<ICommandReceiver>(
                o => o.Target
            )
            .Throws<Exception>()
            .Verifiable();
         }
        
        
        [Then(@"Операция передается для выполнения адресату")]
        public void ТоОперацияПередаетсяДляВыполненияАдресату()
        {
            _receiverMock.Verify(r => r.Receive(_cmd));
            Assert.Null(_ex);
        }


                 [Then(@"Исполнение приказа завершается выбросом исключения")]
         public void ТоИсполнениеПриказаЗавершаетсяВыбросомИсключения()
         {
             Assert.NotNull(_ex);
         }

        
    }
}
