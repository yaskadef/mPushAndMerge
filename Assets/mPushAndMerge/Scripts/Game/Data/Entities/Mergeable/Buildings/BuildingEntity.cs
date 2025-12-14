using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings
{
    public class BuildingEntity : MergeableEntity, IReadOnlyBuilding
    {
        public BuildingEntity(BuildingEntityData entityData) : base(entityData)
        {
        }

        public int BuildingId => Origin.UniqueId;

        ReadOnlyReactiveProperty<int> IReadOnlyBuilding.Level => Level;

        ReadOnlyReactiveProperty<Vector2Int> IReadOnlyBuilding.Position => Position;
    }
}
