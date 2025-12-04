using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using System.Linq;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps
{
    public class Map : IReadOnlyMap
    {
        public readonly MapData Origin;
        public ObservableList<Entity> Entities = new();

        public int MapId => Origin.MapId;
        IReadOnlyObservableList<Entity> IReadOnlyMap.Entities => Entities;

        public Map(MapData mapData)
        {
            Origin = mapData;

            InitEntitiesList(mapData.Entities);
        }

        private void InitEntitiesList(List<EntityData> entities)
        {
            entities.ForEach(
                entityData => Entities.Add(
                    EntityFactory.Create(entityData)
                )
            );

            Entities.ObserveAdd().Subscribe(e =>
            {
                var newEntity = e.Value;
                Origin.Entities.Add(newEntity.Origin);
            });

            Entities.ObserveRemove().Subscribe(e =>
            {
                var removedEntity = e.Value;
                var removedEntityData = Origin.Entities.FirstOrDefault(ed => ed.UniqueId == removedEntity.UniqueId);
                Origin.Entities.Remove(removedEntityData);
            });
        }
    }
}
