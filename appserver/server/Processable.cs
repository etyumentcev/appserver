namespace AppServer.Commands
{
    public class Processable : IProcessable
    {
        IDictionary<string, object> _context;

        public Processable(IDictionary<string, object> context)
        {
            _context = context;
        }

        public bool CanContinue => (bool)_context["canContinue"];

        public void Process()
        {
            ((Action)_context["process"])();
        }

        public void Terminate(Exception ex)
        {
            ((Action<Exception>)_context["terminate"])(ex);
        }
    }
}
