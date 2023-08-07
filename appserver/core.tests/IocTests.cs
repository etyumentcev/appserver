namespace AppServer
{
    public class IocTests
    {
        [Test]
        public void IocShouldUpdateResolveDependencyStrategy()
        {
            bool wasCalled = false;

            Ioc.Resolve<ICommand>(
                "Update Ioc Resolve Dependency Strategy",
                (Func<string, object[], object> args) => 
                {
                    wasCalled = true;
                    return args;
                }
            ).Execute();

            Assert.IsTrue( wasCalled );
        }

        [Test]
        public void IocShouldThrowArgumentExceptionIfDependencyIsNotFound()
        {
            Assert.Throws<ArgumentException>(
                () => Ioc.Resolve<object>("UnexistingDependency")
            );
        }

        [Test]
        public void IocShouldThrowInvalidCastExceptionIfDependencyResolvesAnotherType()
        {
            Assert.Throws<InvalidCastException>(
              () => Ioc.Resolve<string>(
                "Update Ioc Resolve Dependency Strategy",
                (Func<string, object[], object> args) => args
              )
            );
        }

    }
}