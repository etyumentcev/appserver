namespace AppServer
{
    public class Ioc
    {
        public static T Resolve<T>(string dependency, params object[] args)
        {
            return (T) new object();
        }
    }
}
