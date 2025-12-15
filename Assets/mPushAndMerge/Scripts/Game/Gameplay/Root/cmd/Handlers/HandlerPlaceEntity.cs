using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities;
using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            var currentMap = gameData.CurrentMap 
                ?? throw new InvalidOperationException($"CurrentMap not found");

            var settings = CreatePlaceSettings(command);

            var entityData = EntityDataFactory.Create(settings);
            entityData.UniqueId = gameData.CreateGlobalEntityId();

            var entity = EntityFactory.Create(entityData);

            currentMap.Entities.Add(entity);

            return true;
        }

        private static EntityPlaceSettings CreatePlaceSettings(CmdPlaceEntity command)
        {
            return command.EntityType switch
            {
                EntityType.Building => new MergeableEntityPlaceSettings
                {
                    EntityType = EntityType.Building,
                    ConfigId = command.ConfigId,
                    PositionX = command.PositionX,
                    PositionY = command.PositionY,
                    Level = command.Level

                },
                _ => new EntityPlaceSettings
                {
                    EntityType = command.EntityType,
                    ConfigId = command.ConfigId,
                    PositionX = command.PositionX,
                    PositionY = command.PositionY,
                }
            };
        }
    }
}
