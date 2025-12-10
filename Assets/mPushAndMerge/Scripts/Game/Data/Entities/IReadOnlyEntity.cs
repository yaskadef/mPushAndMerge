using R3;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities
{
    public interface IReadOnlyEntity
    {
        int UniqueId { get; }
        string ConfigId { get; }
        EntityType EntityType { get; }


        ReadOnlyReactiveProperty<Vector2Int> Position { get; }
    }
}
