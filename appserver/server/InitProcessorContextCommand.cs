using System.Collections.Concurrent;

namespace App.Commands
{
    public class InitProcessorContextCommand : ICommand
    {
        IDictionary<string, object> _context;
        public InitProcessorContextCommand(IDictionary<string, object> context)
        {
            _context = context;
        }

        public void Execute()
        {
            var queue = new BlockingCollection<ICommand>();
            _context.Add("queue", queue);

            _context["exceptionHandler"] = (ICommand cmd, Exception ex) =>
            {
                throw ex;
            };

            _context["terminate"] = (Exception ex) =>
            {
                _context["canContinue"] = false;
                _context.Add("terminateException", ex);
            };


            _context.Add("canContinue", true);

            _context.Add("process", () =>
            {
                var cmd = queue.Take();
                try
                {
                    cmd.Execute();
                }
                catch (Exception ex)
                {
                    ((Action<ICommand, Exception>)_context["exceptionHandler"])(cmd, ex);
                }
            });
        }
    }
}
