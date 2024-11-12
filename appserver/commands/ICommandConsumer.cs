namespace App.Commands
{
    public interface ICommandConsumer
    {
        void Receive(ICommand cmd);
    }
}
