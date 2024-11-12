namespace App.Scopes
{
    public interface IDependencyResolver
    {
        object Resolve(string dependency, object[] args);
    }
}
