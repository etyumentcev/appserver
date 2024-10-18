namespace Game;

public class Angle
{
    sbyte _d;
    sbyte  _n;

    public Angle(sbyte d, sbyte n) 
    {
        if(_d >= n )
        {
            throw new ArgumentException("d must be less than n");
        }
        _d = d;
        _n = n;
    }

    public static Angle operator+(Angle a1, Angle a2)
    {
        if(a1._n != a2._n)
        {
            throw new ArgumentException("Operands Angle must have same division");
        }

        return new Angle( Convert.ToSByte(((int)a1._d + (int)a2._d) % a1._n) , a1._n);
    }

    public static bool operator==(Angle a1, Angle a2)
    {
        return a1.Equals(a2);
    }

    public static bool operator!=(Angle a1, Angle a2)
    {
        return !(a1 == a2);
    }    

    public override bool Equals(object? obj)
    {
        if(obj is Angle)
        {
            Angle other = (Angle)obj;
            return _d == other._d && _n == other._n;
        }
        else
        { 
            return false; 
        }
    }

    public override string ToString()
    {
        return $"Angle({_d}, {_n})";   
    }


    public override int GetHashCode()
    {
        return ( ((double)_d) / _n * 360 ).GetHashCode();
    }
}
