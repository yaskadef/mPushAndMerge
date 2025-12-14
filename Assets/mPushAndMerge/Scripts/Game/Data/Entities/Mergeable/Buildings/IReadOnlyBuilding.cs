using R3;
using System;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings
{
    public interface IReadOnlyBuilding
    {
        int BuildingId { get; }
        string ConfigId { get; }
        ReadOnlyReactiveProperty<int> Level { get; }
        ReadOnlyReactiveProperty<Vector2Int> Position { get; }
    }
}
