using Assets.mPushAndMerge.Scripts.Game.Settings.Entities;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Maps
{
    [Serializable]
    public class MapInitialStateSettings
    {
        public List<EntityInitialStateSettings> Entities;
        public List<MergeableEntityInitialStateSettings> MergeableEntities;
    }
}
