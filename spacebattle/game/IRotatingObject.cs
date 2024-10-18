namespace Game
{
    public interface IRotatingObject
    {
        Angle Angle
        {
            get;
            set;
        }    
        Angle AngularVelocity
        {
            get;
        }
    }
}
