using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using ObservableCollections;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root
{
    public class Gameplay : IReadOnlyGameplay
    {
        public readonly GameplayData Origin;
        public readonly ReactiveProperty<int> CurrentMapId;
        public readonly ObservableList<Map> Maps = new();

        ReadOnlyReactiveProperty<int> IReadOnlyGameplay.CurrentMapId => CurrentMapId;

        IReadOnlyObservableList<Map> IReadOnlyGameplay.Maps => Maps;

        public Gameplay(GameplayData gameplayData)
        {
            Origin = gameplayData;
            CurrentMapId = new ReactiveProperty<int>(gameplayData.CurrentMapId);

            InitMaps(gameplayData.Maps);
        }

        public int CreateGlobalEntityId()
        {
            return Origin.CreateGlobalEntityId();
        }

        private void InitMaps(List<MapData> maps)
        {
            maps.ForEach(map => 
            {
                Maps.Add(new Map(map));
            });

            Maps.ObserveAdd().Subscribe(e =>
            {
                var addedMap = e.Value;
                Origin.Maps.Add(addedMap.Origin);
            });

            Maps.ObserveRemove().Subscribe(e =>
            {
                var removedMap = e.Value;
                var removedMapData = Origin.Maps.FirstOrDefault(m => m.MapId == removedMap.MapId);
                Origin.Maps.Remove(removedMapData);
            });
        }
    }
}
