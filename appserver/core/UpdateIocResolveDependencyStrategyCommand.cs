﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Impl
{
    internal class UpdateIocResolveDependencyStrategyCommand : ICommand
    {
        Func<Func<string, object[], object>, Func<string, object[], object> > _updater;

        public UpdateIocResolveDependencyStrategyCommand(
            Func<Func<string, object[], object>, Func<string, object[], object> > updater
        ) => _updater = updater;

        public void Execute()
        {
            Ioc._strategy = _updater(Ioc._strategy); 
        }
    }
}
