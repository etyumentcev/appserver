using AppServer;

namespace SpaceBattle
{
    public class MoveCommand : ICommand
    {
        IMovable _movable;
        public MoveCommand(IMovable movable) => _movable = movable;

        public void Execute() 
        {
            _movable.Location += _movable.Velocity;
        }
    }
}