using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System.Linq;
using UnityEngine;


namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayMapInitializer
    {
        private readonly SceneEnterParamsService _enterParamsService;
        private readonly ICommandProcessor _commandProcessor;

        public GameplayMapInitializer(
            SceneEnterParamsService enterParamsService,
            ICommandProcessor commandProcessor)
        {
            _enterParamsService = enterParamsService;
            _commandProcessor = commandProcessor;
        }

        public void Initialize(GameDataProxy gameData)
        {
            var mapId = GetMapIdFromEnterParams();
            gameData.CurrentMapId.Value = mapId;

            var loadedMap = gameData.Maps.FirstOrDefault(m => m.MapId == mapId);
            if (loadedMap == null)
            {
                _commandProcessor.Process(new CmdCreateMap(mapId));

                loadedMap = gameData.Maps.First(m => m.MapId == mapId);
            }
        }

        private int GetMapIdFromEnterParams()
        {
            return _enterParamsService.SceneEnterParams is GameplayEnterParams enterParams ? enterParams.MapId : 0;
        }
    }
}
