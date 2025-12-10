using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable
{
    public interface IReadOnlyMergeableEntity : IReadOnlyEntity
    {
        ReadOnlyReactiveProperty<int> Level { get; }
    }
}
