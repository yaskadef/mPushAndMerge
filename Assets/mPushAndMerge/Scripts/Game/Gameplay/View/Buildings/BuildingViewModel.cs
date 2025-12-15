using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable.Buildings;
using R3;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        public readonly int BuildingEntityId;

        public ReadOnlyReactiveProperty<int> Level;
        public ReadOnlyReactiveProperty<Vector2Int> Position;

        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();

        public BuildingViewModel(
            IReadOnlyBuilding buildingEntity,
            BuildingSettings buildingSettings)
        {
            foreach (var levelSettings in buildingSettings.Levels )
            {
                _levelSettingsMap[levelSettings.Level] = levelSettings;
            }

            BuildingEntityId = buildingEntity.BuildingId;

            Level = buildingEntity.Level;
            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetCurrentLevelSettings()
        {
            return GetLevelSettings(Level.CurrentValue);
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}
