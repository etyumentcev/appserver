namespace AppServer.Commands
{
    public interface ICommandConsumer
    {
        void Receive(ICommand cmd);
    }
}
