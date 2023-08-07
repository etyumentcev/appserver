namespace AppServer
{
    /// <summary>
    /// Команда.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить Команду.
        /// 
        /// Если Команда по какой-либо причине не может быть выполнена, 
        /// то выбрасывается исключение <see cref="System.Exception"/>
        /// </summary>
        void Execute();
    }
}
