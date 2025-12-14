using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using ObservableCollections;
using R3;
using System.Collections.Generic;
using System.Linq;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root
{
    public class GameDataProxy
    {
        public readonly GameData Origin;
        public readonly ReactiveProperty<int> CurrentMapId;
        public readonly ObservableList<Map> Maps = new();

        public Map CurrentMap
        {
            get
            {
                if(_currentMap != null) return _currentMap;
                else
                {
                    _currentMap = Maps.FirstOrDefault(m => m.MapId == CurrentMapId.Value);
                    return _currentMap;
                }
            }
            private set
            {
                _currentMap = value;
            }
        }

        private Map _currentMap = null;

        public GameDataProxy(GameData gameplayData)
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
            CurrentMapId.Subscribe(_ => CurrentMap = null);

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
