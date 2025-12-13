using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd.Handlers
{
    public class HandlerPlaceEntity : ICommandHandler<CmdPlaceEntity>
    {
        private readonly IGameDataProvider _gameDataProvider;

        public HandlerPlaceEntity(IGameDataProvider gameDataProvider)
        {
            _gameDataProvider = gameDataProvider;
        }

        public bool Handle(CmdPlaceEntity command)
        {
            var gameData = _gameDataProvider.GameData;
            var currentMap = gameData.CurrentMap;

            Debug.Log($"Place Entity, current map id: {currentMap.MapId}");

            if (currentMap == null)
                throw new Exception($"Couldn`t find Map with id: {gameData.CurrentMapId}");

            var entityType = command.EntityType;
            var entityData = entityType switch
            {
                EntityType.Building => EntityDataFactory.Create<BuildingEntityData>(
                    entityType, 
                    command.ConfigId, 
                    command.PositionX, 
                    command.PositionY, 
                    command.Level
                ),
                _ => throw new NotImplementedException()
            };

            var entity = EntityFactory.Create(entityData);

            currentMap.Entities.Add(entity);

            foreach (var ent in currentMap.Entities)
            {
                Debug.Log(ent.ConfigId);
            }

            return true;
        }
    }
}
