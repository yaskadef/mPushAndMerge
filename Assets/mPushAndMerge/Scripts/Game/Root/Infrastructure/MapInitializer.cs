using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System.Linq;
using UnityEngine;


namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure
{
    public class MapInitializer : IMapInitializer
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IGameDataProvider _dataProvider;
        private readonly BuildingService _buildingService;

        public MapInitializer(
            ICommandProcessor commandProcessor,
            IGameDataProvider dataProvider,
            BuildingService buildingService)
        {
            _commandProcessor = commandProcessor;
            _dataProvider = dataProvider;
            _buildingService = buildingService;
        }

        public void Initialize(int mapId)
        {
            var gameData = _dataProvider.GameData;

            gameData.CurrentMapId.Value = mapId;

            var loadedMap = gameData.Maps.FirstOrDefault(m => m.MapId == mapId);
            if (loadedMap == null)
            {
                _commandProcessor.Process(new CmdCreateMap(mapId));

                loadedMap = gameData.Maps.First(m => m.MapId == mapId);
                //_buildingService.ConnectToMapEntities(loadedMap.Entities);
            }
        }
    }
}
