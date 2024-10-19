namespace Game;

using AppServer;

public class ApplyActionOrderCommand(IApplyActionOrder order) : ICommand
{
        public void Execute()
        {
            var cmd = order.Command;
            var target = order.Target;

            target.Receive(cmd);
        }
}
