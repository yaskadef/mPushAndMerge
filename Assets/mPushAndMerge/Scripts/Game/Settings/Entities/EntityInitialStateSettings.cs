using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities
{
    [Serializable]
    public class EntityInitialStateSettings
    {
        public string ConfigId;
        public EntityType Type;
        public int PositionX;
        public int PositionY;
    }
}
