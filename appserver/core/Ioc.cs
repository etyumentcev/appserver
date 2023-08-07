using System;

namespace AppServer
{
    public class Ioc
    {
        internal static Func<string, object[], object> _strategy =
            (Func<string, object[], object>)((dependency, args) =>
            {
                if ("Update Ioc Resolve Dependency Strategy" == dependency)
                {
                    return new AppServer.Impl.UpdateIocResolveDependencyStrategyCommand(
                      (Func < Func<string, object[], object>, Func<string, object[], object> >) args[0]
                    );
                }
                else
                {
                    throw new ArgumentException(@"Dependency {dependency} is not found.");
                }

            });

        public static T Resolve<T>(string dependency, params object[] args)
        {
            return (T) _strategy(dependency, args);
        }
    }
}
