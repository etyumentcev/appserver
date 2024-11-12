namespace App.Commands
{
    public class RegisterProcessorCommand : ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<ICommand>("IoC.Register", "Server.CommandProcessor", (object[] args) =>
            {
                IDictionary<string, object> context = new Dictionary<string, object>();
                new InitProcessorContextCommand(context).Execute();
                context.Add("processor", new Processor(new Processable(context)));
                return context;
            }).Execute();
        }
    }
}
