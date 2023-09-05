namespace AppServer.Scopes
{
    public class SetCurrentScopeCommand : ICommand
    {
        object _scope;

        public SetCurrentScopeCommand(object scope)
        {
            _scope = scope;
        }

        public void Execute()
        {
            InitCommand.currentScopes.Value = _scope;
        }
    }
}
