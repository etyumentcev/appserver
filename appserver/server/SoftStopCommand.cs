using System.Collections.Concurrent;

namespace AppServer.Commands
{
    public class SoftStopCommand : ICommand
    {
        IDictionary<string, object> _context;
        public SoftStopCommand(IDictionary<string, object> context)
        {
            _context = context;
        }

        public void Execute()
        {
            Action previousProcess = (Action)_context["process"];
            _context["process"] = () =>
            {
                previousProcess();

                var queue = ((BlockingCollection<ICommand>)_context["queue"]);

                if (0 == queue.Count)
                {
                    _context["canContinue"] = false;
                }
            };
        }
    }
}
