﻿namespace App.Scopes
{
    public class ClearCurrentScopeCommand : ICommand
    {
        public void Execute()
        {
            InitCommand.currentScopes.Value = null;
        }
    }
}
