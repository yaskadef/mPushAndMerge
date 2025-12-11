using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<Type, object> _handlersMap = new Dictionary<Type, object>();

        public bool Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (_handlersMap.TryGetValue(typeof(TCommand), out var h))
            {
                if (h is ICommandHandler<TCommand> handler)
                {
                    bool result = handler.Handle(command);

                    if (result)
                    {
                        Debug.Log("Command executed");
                        return true;
                    }
                }
            }

            return false;
        }

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlersMap[typeof(TCommand)] = handler;
        }
    }
}
