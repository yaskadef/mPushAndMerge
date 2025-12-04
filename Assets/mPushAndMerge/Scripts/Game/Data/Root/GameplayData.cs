using Assets.mPushAndMerge.Scripts.Game.Data.Root.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root
{
    public class GameplayData
    {
        public int GlobalEntityId { get; set; }
        public int CurrentMapId { get; set; }
        public List<MapData> Maps { get; set; }

        public int CreateGlobalEntityId()
        {
            return GlobalEntityId++;
        }
    }
}
