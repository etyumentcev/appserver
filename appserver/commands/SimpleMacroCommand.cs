namespace App.Commands
{
    public class SimpleMacroCommand : ICommand
    {
        IEnumerable<ICommand> _cmds;
        public SimpleMacroCommand(IEnumerable<ICommand> cmds) => _cmds = cmds;
        public void Execute() 
        { 
            foreach (var cmd in _cmds) 
            {
                cmd.Execute();
            }
        }
    }
}
