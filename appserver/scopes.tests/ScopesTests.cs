namespace AppServer.Scopes
{
    public class Tests : IDisposable
    {
        public Tests()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
        }

        [Fact]
        public void Ioc_Should_Resolve_Registered_Dependency_In_CurrentScope()
        {
            Ioc.Resolve<ICommand>("IoC.Register", "someDependency", (object[] args) => (object)1).Execute();

            Assert.Equal(1, Ioc.Resolve<int>("someDependency"));
        }

        [Fact]
        public void Ioc_Should_Throw_Exception_On_Unregistered_Dependency_In_CurrentScope()
        {
            Assert.ThrowsAny<Exception>(() => Ioc.Resolve<int>("someDependency"));
        }

        [Fact]
        public void Ioc_Should_Use_Parent_Scope_If_Resolving_Dependency_Is_Not_Defined_In_Current_Scope()
        {
            Ioc.Resolve<ICommand>("IoC.Register", "someDependency", (object[] args) => (object)1).Execute();

            var parentIoCScope = Ioc.Resolve<object>("IoC.Scope.Current");

            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

            Assert.Equal(iocScope, Ioc.Resolve<object>("IoC.Scope.Current"));
            Assert.Equal(1, Ioc.Resolve<int>("someDependency"));
        }

        [Fact]
        public void Paret_Scope_Can_Be_Set_Manually_For_Creating_Scope()
        {
            var scope1 = Ioc.Resolve<object>("IoC.Scope.Create");
            var scope2 = Ioc.Resolve<object>("IoC.Scope.Create", scope1);

            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", scope1);
            Ioc.Resolve<ICommand>("IoC.Register", "someDependency", (object[] args) => (object)2).Execute();
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Set", scope2);

            Assert.Equal(2, Ioc.Resolve<int>("someDependency"));
        }

        public void Dispose()
        {
            Ioc.Resolve<ICommand>("IoC.Scope.Current.Clear").Execute();
        }
    }
}