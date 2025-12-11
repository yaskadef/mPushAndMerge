using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd.Handlers
{
    public class HandlerPlaceEntity : ICommandHandler<CmdPlaceEntity>
    {
        private readonly GameDataProxy _gameDataProxy;

        public HandlerPlaceEntity(GameDataProxy gameDataProxy)
        {
            _gameDataProxy = gameDataProxy;
        }

        public bool Handle(CmdPlaceEntity command)
        {
            var currentMap = _gameDataProxy.CurrentMap;
            if (currentMap == null)
                throw new Exception($"Couldn`t find Map with id: {_gameDataProxy.CurrentMapId}");

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

            return true;
        }
    }
}
