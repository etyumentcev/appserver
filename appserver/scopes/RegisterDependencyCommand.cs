namespace AppServer.Scopes
{
    public class RegisterDependencyCommand : ICommand
    {
        string _dependency;
        Func<object[], object> _dependencyResolverStratgey;

        public RegisterDependencyCommand(string dependency, Func<object[], object> depednecyResolverStrategy)
        {
            _dependency = dependency;
            _dependencyResolverStratgey = depednecyResolverStrategy;
        }

        public void Execute()
        {
            var currentScope = Ioc.Resolve<IDictionary<string, Func<object[], object>>>("IoC.Scope.Current");
            currentScope.Add(_dependency, _dependencyResolverStratgey);
        }
    }
}
