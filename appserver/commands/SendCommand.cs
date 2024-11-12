namespace App.Commands
{
    public class SendCommand : ICommand
    {
        ICommand _repeatableCommand;
        ICommandConsumer _receiver;

        public SendCommand(ICommand cmd, ICommandConsumer receiver)
        {
            _repeatableCommand = cmd;
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Receive(_repeatableCommand);
        }
    }
}
