using AppServer;

namespace SpaceBattle
{
    public class MoveCommand(IMovingObject movingObject) : ICommand
    {
        public void Execute() 
        {
            movingObject.Location += movingObject.Velocity;
        }
    }
}