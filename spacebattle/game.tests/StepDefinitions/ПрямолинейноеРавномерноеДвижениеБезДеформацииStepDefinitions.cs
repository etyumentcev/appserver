using Moq;
using SpaceBattle;

namespace Spacebattle.tests.StepDefinitions
{
    [Binding]
    public class ПрямолинейноеРавномерноеДвижениеБезДеформацииStepDefinitions
    {
        Mock<IMovingObject> _obj = new Mock<IMovingObject>();
        Exception? _ex = null;

        [Given(@"объект находится в точке \((.*), (.*)\)")]
        public void GivenОбъектНаходитсяВТочке(int p0, int p1)
        {
            _obj.SetupGet<Vector>(
                o => o.Location
            )
            .Returns(new Vector(p0, p1))
            .Verifiable();
        }

        [Given(@"объект имеет мгновенную скорость \((.*), (.*)\)")]
        public void GivenОбъектИмеетМгновеннуюСкорость(int p0, int p1)
        {
            _obj.SetupGet<Vector>(
                o => o.Velocity
            )
            .Returns(new Vector(p0, p1))
            .Verifiable();
        }

        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void WhenПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
        {
            try
            {
                new MoveCommand(_obj.Object).Execute();
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [Then(@"объект перемещается в точку \((.*), (.*)\)")]
        public void ThenОбъектПеремещаетсяВТочку(int p0, int p1)
        {
            _obj.VerifySet(o => o.Location = new Vector(p0, p1));
            Assert.Null(_ex);
        }

        [Given("объект, положение в пространстве которого, определить невозможно")]
        public void GivenОбъектПоложениеВПространствеКоторогоОпределитьНевозможно()
        {
            _obj.SetupGet<Vector>(
                o => o.Location
            )
            .Throws<Exception>()
            .Verifiable();
        }


        [Given(@"объект, который не имеет мгновенную скорость")]
        public void GivenОбъектКоторыйНеИмеетМгновеннуюСкорость()
        {
            _obj.SetupGet<Vector>(
                o => o.Velocity
            )
            .Throws<Exception>()
            .Verifiable();
        }

        [Given("объект, положение в пространстке которого изменить нельзя")]
        public void GivenОбъектПоложениеВПространсткеКоторогоИзменитьНельзя()
        {
            _obj.SetupSet(o => o.Location = It.IsAny<Vector>()).Throws<Exception>().Verifiable();
        }

        [Then(@"операция прямолиенейного движения прерывается выбросом исключения")]
        public void ThenОперацияПрямолинейногоДвиженияПрерываетсяВыбросомИсключения()
        {
            Assert.NotNull(_ex);
        }
    }
}
