namespace AppServer.Commands
{
    public interface IProcessable
    {
        bool CanContinue
        {
            get;
        }
        void Process();
    }
}
