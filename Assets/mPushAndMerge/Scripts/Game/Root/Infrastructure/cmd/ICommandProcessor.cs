using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd
{
    public interface ICommandProcessor
    {
        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        public bool Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
