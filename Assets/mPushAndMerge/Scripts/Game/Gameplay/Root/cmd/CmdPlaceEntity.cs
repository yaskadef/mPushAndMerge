using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd
{
    public class CmdPlaceEntity : ICommand
    {
        public readonly EntityType EntityType;
        public readonly string ConfigId;
        public readonly int PositionX;
        public readonly int PositionY;
        public readonly int Level;

        public CmdPlaceEntity(
            EntityType entityType, 
            string configId, 
            int posX, 
            int posY, 
            int lvl = 1)
        {
            EntityType = entityType;
            ConfigId = configId;
            PositionX = posX;
            PositionY = posY;
            Level = lvl;
        }
    }
}
