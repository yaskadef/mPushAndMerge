using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps
{
    public class MapData
    {
        public int MapId { get; set; }
        public List<EntityData> Entities;
    }
}
