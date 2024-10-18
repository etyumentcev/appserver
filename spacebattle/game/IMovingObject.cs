namespace SpaceBattle
{
    public interface IMovingObject
    {
        Vector Location
        {
            get;
            set;
        }

        Vector Velocity
        {
            get;
        }
    }
}
