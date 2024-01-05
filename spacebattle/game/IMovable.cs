namespace SpaceBattle
{
    public interface IMovable
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
