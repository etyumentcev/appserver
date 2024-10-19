namespace Game;

using AppServer;

public interface ICommandReceiver
{
    void Receive(ICommand command);
}
