namespace AppServer
{
    /// <summary>
    /// Контейнер инверсии зависимотей (Расширяемая фабрика).
    /// </summary>
    public class Ioc
    {
        internal static Func<string, object[], object> _strategy =
            (string dependency, object[] args) =>
            {
                if ("Update Ioc Resolve Dependency Strategy" == dependency)
                {
                    return new AppServer.Impl.UpdateIocResolveDependencyStrategyCommand(
                      (Func<Func<string, object[], object>, Func<string, object[], object>>)args[0]
                    );
                }
                else
                {
                    throw new ArgumentException(@"Dependency {dependency} is not found.");
                }

            };

        /// <summary>
        /// Разрешение зависимости.
        /// </summary>
        /// <typeparam name="T">Ожидаемый тип объекта, получаемого в результате разрешения зависимости.
        /// Если полученный объект невозможно привести в запрашиваемому типу, то выбрасывается исключение
        /// <see cref="System.InvalidCastException"/>
        /// </typeparam>
        /// <param name="dependency">Строковое имя разрешаемой зависимости. В реализации контейнера 
        /// по умолчанию определенп только одна зависимость "Update Ioc Resolve Dependency Strategy", 
        /// которая позволяет переопределить стратегию разрешения зависимостей по-умолчанию.</param>
        /// <param name="args">Произвольное количество аргументов, которые получает на вход стратегия 
        /// разрешения зависимостей. Для переопределения стратегии разрешения зависимостей по-умолчанию
        /// на вход подается лямбда функция типа Func<Func<string, object[], object>, Func<string, object[], object> >,
        /// которая на вход принимает текущую стратегию разрешения зависмисостей типа Func<string, object[], object>, 
        /// на выходе возвращает новую стратегию типа Func<string, object[], object>.
        /// </param>
        /// <returns>Объект, полученный в результате разрешения зависимости.
        /// Если указана несуществующая зависимость, то выбрасывается исключение 
        /// <see cref="System.ArgumentException"/>
        /// </returns>
        public static T Resolve<T>(string dependency, params object[] args)
        {
            return (T)_strategy(dependency, args);
        }
    }
}
