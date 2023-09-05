using System.Collections.Concurrent;

namespace AppServer.Scopes
{
    public class InitCommand : ICommand
    {
        internal static ThreadLocal<object> currentScopes =
            new ThreadLocal<object>(true);

        static ConcurrentDictionary<string, Func<object[], object>> rootScope =
            new ConcurrentDictionary<string, Func<object[], object>>();

        static bool _alreadyExecutesScuccessfully = false;
        public void Execute()
        {
            if (_alreadyExecutesScuccessfully)
                return;

            lock (rootScope)
            {
                rootScope.TryAdd(
                    "IoC.Scope.Current.Set",
                    (object[] args) => new SetCurrentScopeCommand(args[0])
                );

                rootScope.TryAdd(
                    "IoC.Scope.Current.Clear",
                    (object[] args) => new ClearCurrentScopeCommand()
                );

                rootScope.TryAdd(
                    "IoC.Scope.Current",
                    (object[] args) => currentScopes.Value != null ? currentScopes.Value! : rootScope
                );

                rootScope.TryAdd(
                    "IoC.Scope.Parent",
                    (object[] args) => throw new Exception("The root scope has no a parent scope.")
                );

                rootScope.TryAdd(
                    "IoC.Scope.Create.Empty",
                    (object[] args) => new Dictionary<string, Func<object[], object>>()
                );

                rootScope.TryAdd(
                    "IoC.Scope.Create",
                    (object[] args) =>
                    {
                        var creatingScope = Ioc.Resolve<IDictionary<string, Func<object[], object>>>("IoC.Scope.Create.Empty");

                        if (args.Length > 0)
                        {
                            var parentScope = args[0];
                            creatingScope.Add("IoC.Scope.Parent", (object[] args) => parentScope);
                        }
                        else
                        {
                            var parentScope = Ioc.Resolve<object>("IoC.Scope.Current");
                            creatingScope.Add("IoC.Scope.Parent", (object[] args) => parentScope);
                        }
                        return creatingScope;
                    }
                );

                rootScope.TryAdd(
                    "IoC.Register",
                    (object[] args) => new RegisterDependencyCommand((string)args[0], (Func<object[], object>)args[1])
                );

                Ioc.Resolve<ICommand>(
                    "Update Ioc Resolve Dependency Strategy",
                    (Func<string, object[], object> oldStrategy) =>
                    (string dependency, object[] args) =>
                    {
                        var scope = currentScopes.Value != null ? currentScopes.Value! : rootScope;
                        var dependencyResolver = new DependencyResolver(scope);

                        return dependencyResolver.Resolve(dependency, args);
                    }
                ).Execute();

                _alreadyExecutesScuccessfully = true;
            }
        }
    }
}
