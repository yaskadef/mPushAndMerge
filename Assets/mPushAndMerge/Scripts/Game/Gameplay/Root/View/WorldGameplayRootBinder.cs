using Assets.mPushAndMerge.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootBinder : MonoBehaviour
    {
        [SerializeField] private Transform entitiesContainer;

        private WorldGameplayRootViewModel _rootViewModel;

        private Dictionary<int, BuildingBinder> _buildingBindersMap = new();
        private CompositeDisposable _disposables = new();

        [Inject]
        public void Construct(WorldGameplayRootViewModel rootViewModel)
        {
            _rootViewModel = rootViewModel;
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        public void InitWorldView()
        {
            foreach (var building in _rootViewModel.AllBuildings)
            {
                CreateBuilding(building);
            }

            _rootViewModel
                .AllBuildings
                .ObserveAdd()
                .Subscribe(e => CreateBuilding(e.Value))
                .AddTo(_disposables);

            _rootViewModel
                .AllBuildings
                .ObserveRemove()
                .Subscribe(e => RemoveBuilding(e.Value))
                .AddTo(_disposables);
        }

        private void CreateBuilding(BuildingViewModel building)
        {
            //TODO PoolMono
            var buildingBinder = Instantiate(
                Resources.Load<BuildingBinder>(building.GetCurrentLevelSettings().PrefabSkinPath), entitiesContainer);

            buildingBinder.Bind(building);

            _buildingBindersMap[building.BuildingEntityId] = buildingBinder;
        }

        private void RemoveBuilding(BuildingViewModel building)
        {
            if (_buildingBindersMap.TryGetValue(building.BuildingEntityId, out var buildingBinder))
            {
                //TODO PoolMono
                Destroy(buildingBinder.gameObject);
                _buildingBindersMap.Remove(building.BuildingEntityId);
            }
        }
    }
}
