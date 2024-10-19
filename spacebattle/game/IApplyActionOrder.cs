namespace Game;

using AppServer;

public interface IApplyActionOrder
{
    ICommand Command
    {
        get;
    }

    ICommandReceiver Target
    {
        get;
    }
}
