using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using Assets.mPushAndMerge.Scripts.Game.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd.Handlers
{
    public class HandlerCreateMap : ICommandHandler<CmdCreateMap>
    {
        private readonly IGameDataProvider _gameDataProvider;
        private readonly ISettingsProvider _settingsProvider;

        public HandlerCreateMap(IGameDataProvider gameDataProvider, ISettingsProvider settingsProvider)
        {
            _gameDataProvider = gameDataProvider;
            _settingsProvider = settingsProvider;
        }

        public bool Handle(CmdCreateMap command)
        {
            var gameData = _gameDataProvider.GameData;
            bool isAlreadyExist = gameData.Maps.Any(m => m.MapId == command.MapId);
            
            if (isAlreadyExist) 
                throw new Exception($"Map with id {command.MapId} already exists");


            var targetMapSettings = _settingsProvider.GameSettings.MapsSettings.Maps.First(m => m.MapId == command.MapId);

            List<EntityData> entityDatas = new List<EntityData>();
            foreach (var entityInitialSettings in targetMapSettings.InitialState.Entities)
            {
                var entityData = EntityDataFactory.Create(entityInitialSettings);
                entityData.UniqueId = gameData.CreateGlobalEntityId();
                
                entityDatas.Add(entityData);
            }

            foreach (var mergeableEntityInitialSettings in targetMapSettings.InitialState.MergeableEntities)
            {
                var entityData = EntityDataFactory.Create(mergeableEntityInitialSettings);
                entityData.UniqueId = gameData.CreateGlobalEntityId();

                entityDatas.Add(entityData);
            }


            var mapData = new MapData
            {
                MapId = command.MapId,
                Entities = entityDatas
            };
            var map = new Map(mapData);
            gameData.Maps.Add(map);

            return true;
        }
    }
}
