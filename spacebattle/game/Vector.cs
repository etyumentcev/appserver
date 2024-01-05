namespace SpaceBattle
{
    public class Vector
    {
        int[] _coords;

        public Vector(params int[] coords) => _coords = coords;

        public override bool Equals(object? obj)
        {
            if(obj is Vector)
            {
                return _coords.SequenceEqual((obj as Vector)!._coords);
            }
            else
            { 
                return false; 
            }
        }

        public override int GetHashCode()
        {
            return _coords.GetHashCode();
        }

        public static Vector operator+ (Vector addition1, Vector addition2)
        {
            return new Vector(addition1._coords.Zip(addition2._coords, (x, y) => x + y).ToArray());
        }
       
    }
}
