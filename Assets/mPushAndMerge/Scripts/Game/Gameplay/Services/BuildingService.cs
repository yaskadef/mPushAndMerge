using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.View.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable.Buildings;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using System;


namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Services
{
    public class BuildingService
    {
        public IObservableCollection<BuildingViewModel> AllBuildings => _buildingViewModels;

        private readonly ObservableList<BuildingViewModel> _buildingViewModels = new();
        private readonly Dictionary<int, BuildingViewModel> _buildingViewModelsMap = new();
        private readonly Dictionary<string, BuildingSettings> _buildingsSettingsMap = new();
        private readonly ICommandProcessor _commandProcessor;

        public BuildingService(
            EntitiesSettings entitiesSettings,
            ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;

            foreach (var buildingSettings in entitiesSettings.Buildings)
            {
                _buildingsSettingsMap[buildingSettings.ConfigId] = buildingSettings;
            }
        }

        public void ConnectToMapEntities(IObservableCollection<Entity> entities)
        {
            foreach (var entity in entities)
            {
                if(entity is BuildingEntity buildingEntity)
                {
                    CreateBuildingViewModel(buildingEntity);
                }
            }

            entities.ObserveAdd().Subscribe(e =>
            {
                if(e.Value is BuildingEntity buildingEntity)
                {
                    CreateBuildingViewModel(buildingEntity);
                }
            });

            entities.ObserveRemove().Subscribe(e =>
            {
                if(e.Value is BuildingEntity buildingEntity)
                {
                    RemoveBuildingViewModel(buildingEntity);
                }
            });
        }

        public bool PlaceBuilding(string configId, int posX, int posY, int level)
        {
            return _commandProcessor.Process(
                new CmdPlaceEntity(
                    EntityType.Building, 
                    configId, 
                    posX, 
                    posY, 
                    level)
                );
        }

        private void CreateBuildingViewModel(IReadOnlyBuilding building)
        {
            var buildingViewModel = new BuildingViewModel(building, _buildingsSettingsMap[building.ConfigId]);

            _buildingViewModels.Add(buildingViewModel);
            _buildingViewModelsMap[buildingViewModel.BuildingEntityId] = buildingViewModel;
        }

        private void RemoveBuildingViewModel(IReadOnlyBuilding building)
        {
            if (_buildingViewModelsMap.TryGetValue(
                building.BuildingId, 
                out var buildingViewModel))
            {
                _buildingViewModels.Remove(buildingViewModel);
                _buildingViewModelsMap.Remove(buildingViewModel.BuildingEntityId);
            }
        }
    }
}
