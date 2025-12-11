using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd
{
    public class CommandRegistrar
    {
        public CommandRegistrar(
            ICommandProcessor commandProcessor, 
            ICommandHandler<CmdPlaceEntity> placeEntityHandler)
        {
            Debug.Log("CommandRegistrar");
            commandProcessor.RegisterHandler(placeEntityHandler);
        }
    }
}
