using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable
{
    public class MergeableEntity : Entity, IReadOnlyMergeableEntity
    {
        public readonly ReactiveProperty<int> Level;

        public MergeableEntity(MergeableEntityData entityData) : base(entityData)
        {
            Level = new ReactiveProperty<int>(entityData.Level);
        }

        ReadOnlyReactiveProperty<int> IReadOnlyMergeableEntity.Level => Level;
    }
}
