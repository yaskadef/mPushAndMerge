using Assets.mPushAndMerge.Scripts.Game.Settings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Maps
{
    public static class MapInitialStateSettingExtensions
    {
        public static IEnumerable<EntityPlaceSettings> AllEntities(
            this MapInitialStateSettings mapInitialSettings)
        {
            if(mapInitialSettings.Entities != null)
            {
                foreach (var settings in mapInitialSettings.Entities)
                    yield return settings;
            }

            if (mapInitialSettings.MergeableEntities != null)
            {
                foreach (var settings in mapInitialSettings.MergeableEntities)
                    yield return settings;
            }
        }
    }
}
