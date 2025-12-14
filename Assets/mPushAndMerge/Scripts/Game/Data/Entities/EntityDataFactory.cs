using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities
{
    public static class EntityDataFactory
    {
        public static EntityData Create(EntityPlaceSettings placeSettings)
        {
            switch (placeSettings.EntityType)
            {
                case EntityType.Building:
                    return CreateBuilding(placeSettings);
                default:
                    throw new NotSupportedException($"EntityType {placeSettings.EntityType} is not supported");
            }
        }

        private static EntityData CreateBuilding(EntityPlaceSettings settings)
        {
            if (settings is not MergeableEntityPlaceSettings mergeableSettings)
                throw new InvalidOperationException("Building entity requires mergeable settings");

            return new BuildingEntityData
            {
                EntityType = EntityType.Building,
                ConfigId = mergeableSettings.ConfigId,
                PositionX = mergeableSettings.PositionX,
                PositionY = mergeableSettings.PositionY,
                Level = mergeableSettings.Level
            };
        }
    }
}
