using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;


namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        public IObservableCollection<BuildingViewModel> AllBuildings {  get; }

        public WorldGameplayRootViewModel(BuildingService buildingService)
        {
            AllBuildings = buildingService.AllBuildings;
        }
    }
}
