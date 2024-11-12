namespace App.Commands
{
    public interface IProcessable
    {
        bool CanContinue
        {
            get;
        }
        void Process();
        void Terminate(Exception ex);
    }
}
