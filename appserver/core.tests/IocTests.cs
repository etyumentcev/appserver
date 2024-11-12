namespace App
{
    public class IocTests
    {
        [Fact]
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

            Assert.True(wasCalled);
        }

        [Fact]
        public void IocShouldThrowArgumentExceptionIfDependencyIsNotFound()
        {
            Assert.Throws<ArgumentException>(
                () => Ioc.Resolve<object>("UnexistingDependency")
            );
        }

        [Fact]
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