using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities
{
    public static class EntityFactory
    {
        public static Entity Create(EntityData entityData)
        {
            switch (entityData.EntityType)
            {
                case EntityType.Building:
                    
                    if (entityData is not BuildingEntityData buildingEntityData)
                        throw new Exception("Invalid EntityData type");
                    
                    return new BuildingEntity(buildingEntityData);
                default:
                    throw new Exception($"Not supported entity type({entityData.EntityType})");
            }
        }
    }
}
