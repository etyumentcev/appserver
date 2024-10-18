namespace Game;

using AppServer;

public class RotateCommand(IRotatingObject rotatingObject) : ICommand
{
    public void Execute()
    {
        rotatingObject.Angle += rotatingObject.AngularVelocity;
    }
}
