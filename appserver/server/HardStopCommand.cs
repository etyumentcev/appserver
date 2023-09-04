namespace AppServer.Commands
{
    public class HardStopCommand : ICommand
    {
        IDictionary<string, object> _context;
        public HardStopCommand(IDictionary<string, object> context)
        {
            _context = context;
        }

        public void Execute()
        {
            _context["canContinue"] = false;
        }
    }
}

