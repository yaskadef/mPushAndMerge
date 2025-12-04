using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings
{
    public class BuildingEntity : MergeableEntity, IReadOnlyBuildingEntity
    {
        public BuildingEntity(BuildingEntityData entityData) : base(entityData)
        {
        }
    }
}
