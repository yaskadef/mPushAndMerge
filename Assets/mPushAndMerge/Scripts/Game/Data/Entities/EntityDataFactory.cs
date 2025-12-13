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
        public static EntityData Create(EntityInitialStateSettings initialStateSettings)
        {
            switch (initialStateSettings.Type)
            {
                case EntityType.Building:

                    if (initialStateSettings is not MergeableEntityInitialStateSettings settings)
                        throw new Exception("Invalid initial settings type");
                    
                    return Create<BuildingEntityData>(
                        settings.Type, 
                        settings.ConfigId, 
                        settings.PositionX, 
                        settings.PositionY, 
                        settings.Level);
                default:
                    throw new Exception("Not supported EntityType");
            }
        }

        public static T Create<T>(
            EntityType entityType, 
            string configId, 
            int posX, 
            int posY, 
            int level = 1) where T : EntityData, new()
        {
            var entityData = new T()
            {
                EntityType = entityType,
                ConfigId = configId,
                PositionX = posX,
                PositionY = posY,
            };

            switch (entityData)
            {
                case BuildingEntityData buildingEntityData:
                    UpdateBuildingEntity(buildingEntityData, level);
                    break;
                default:
                    throw new Exception("Not supported EntityType");
            }

            return entityData;
        }

        private static void UpdateBuildingEntity(
            BuildingEntityData entityData, 
            int level) 
        {
            entityData.Level = level;
        }
    }
}
