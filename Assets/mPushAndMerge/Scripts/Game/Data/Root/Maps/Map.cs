using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps
{
    public class Map
    {
        public readonly MapData Origin;
        public ObservableList<Entity> Entities = new();

        public int MapId => Origin.MapId;
        public int MapBorder => Origin.MapBorder;

        private readonly Dictionary<Vector2Int, Entity> _entitiesMap = new();

        public Map(MapData mapData)
        {
            Origin = mapData;

            InitEntitiesList(mapData.Entities);
        }

        public bool IsPositionAvailable(int x, int y)
        {
            if (Mathf.Abs(x) > MapBorder || Mathf.Abs(y) > MapBorder)
                return false;

            if (GetEntityInPosition(x,y) != null)
                return false;

            return true;
        }

        public Entity GetEntityInPosition(int x, int y)
        {
            var position = new Vector2Int(x, y);

            if (_entitiesMap.TryGetValue(position, out var entity))
                return entity;

            return null;
        }

        private void InitEntitiesList(List<EntityData> entities)
        {
            entities.ForEach(entityData => 
            {
                var entity = EntityFactory.Create(entityData);
                
                Entities.Add(entity);
                _entitiesMap[entity.Position.CurrentValue] = entity;
            });

            Entities.ObserveAdd().Subscribe(e =>
            {
                var newEntity = e.Value;
                
                Origin.Entities.Add(newEntity.Origin);
                _entitiesMap[newEntity.Position.CurrentValue] = newEntity;
            });

            Entities.ObserveRemove().Subscribe(e =>
            {
                var removedEntity = e.Value;
                var removedEntityData = Origin.Entities.FirstOrDefault(ed => ed.UniqueId == removedEntity.UniqueId);
                
                Origin.Entities.Remove(removedEntityData);
                _entitiesMap.Remove(removedEntity.Position.CurrentValue);
            });
        }
    }
}
