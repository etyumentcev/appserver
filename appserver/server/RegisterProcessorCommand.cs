using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Commands
{
    public class RegisterProcessorCommand : ICommand
    {
        public void Execute()
        {
            Ioc.Resolve<ICommand>("IoC.Register", "Server.CommandProcessor", (object[] args) =>
            {
                IDictionary<string, object> context = new Dictionary<string, object>();
                new InitProcessorContextCommand(context).Execute();
                new Processor(new Processable(context));
                return context;
            }).Execute();
        }
    }
}
