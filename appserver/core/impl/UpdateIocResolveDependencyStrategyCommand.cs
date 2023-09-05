namespace AppServer.Impl
{
    internal class UpdateIocResolveDependencyStrategyCommand : ICommand
    {
        Func<Func<string, object[], object>, Func<string, object[], object>> _updateIoCStrategy;

        public UpdateIocResolveDependencyStrategyCommand(
            Func<Func<string, object[], object>, Func<string, object[], object>> updater
        )
        {
            _updateIoCStrategy = updater;
        }

        public void Execute()
        {
            Ioc._strategy = _updateIoCStrategy(Ioc._strategy);
        }
    }
}
