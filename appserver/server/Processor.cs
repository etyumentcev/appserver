namespace AppServer.Commands
{
    public class Processor
    {
        Thread _thread;
        IProcessable _processable;

        public Processor(IProcessable context)
        {
            _processable = context;
            _thread = new Thread(Evaluaton);
            _thread.Start();
        }

        public bool Wait(int miliseconds)
        {
            return _thread.Join(miliseconds);
        }

        private void Evaluaton()
        {
            try
            {
                while (_processable.CanContinue)
                {
                    _processable.Process();
                }
            }
            catch (Exception ex)
            {
                _processable.Terminate(ex);
            }
        }
    }
}
