using Moq;
using SpaceBattle;

using Game;

namespace Game.Tests.StepDefinitions
{
    [Binding]
    public class ВращениеВокругСобственнойОсиStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        Mock<IRotatingObject> _obj = new Mock<IRotatingObject>();
        Exception? _ex = null;


        public ВращениеВокругСобственнойОсиStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"объект имеет угол наклона \((.*), (.*)\)")]
        public void ДопустимОбъектИмеетУголНаклона(sbyte p0, sbyte p1)
        {
            _obj.SetupGet<Angle>(
                o => o.Angle
            )
            .Returns(new Angle(p0, p1))
            .Verifiable();
        }
        
        [Given(@"объект имеет мгновенную угловую скорость \((.*), (.*)\)")]
        public void ДопустимОбъектИмеетМгновеннуюУгловуюСкорость(sbyte p0, sbyte p1)
        {
            _obj.SetupGet<Angle>(
                o => o.AngularVelocity
            )
            .Returns(new Angle(p0, p1))
            .Verifiable();
        }

        [Given("объект, угол наклона которого, определить невозможно")]
        public void GivenОбъектУголНаклонаКоторогоОпределитьНевозможно()
        {
            _obj.SetupGet<Angle>(
                o => o.Angle
            )
            .Throws<Exception>()
            .Verifiable();
        }

        [Given("объект, который не имеет мгновенную угловую скорость")]
        public void GivenОбъектКоторыйНеИмеетМгновеннуюУгловуюСкорость()
        {
            _obj.SetupGet<Angle>(
                o => o.AngularVelocity
            )
            .Throws<Exception>()
            .Verifiable();
        }
        
        [Given(@"объект, угол наклона которого изменить нельзя")]
        public void ДопустимОбъектУголНаклонаКоторогоИзменитьНельзя()
        {
            _obj.SetupSet(o => o.Angle = It.IsAny<Angle>()).Throws<Exception>().Verifiable();
        }
        
        [When(@"происходит вращение вокруг собственной оси")]
        public void КогдаПроисходитВращениеВокругСобственнойОси()
        {
            try
            {
                new RotateCommand(_obj.Object).Execute();
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [Then(@"объект получает угол наклона \((.*), (.*)\)")]
        public void ThenОбъектПолучаетУголНаклона(sbyte p0, sbyte p1)
        {
            _obj.VerifySet(o => o.Angle = new Angle(p0, p1));
            Assert.Null(_ex);
        }

        [Then(@"операция вращения прерывается выбросом исключения")]
        public void ThenОперацияВращенияПрерываетсяВыбросомИсключения()
        {
            Assert.NotNull(_ex);
        }
    }
}
