using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using ObservableCollections;
using R3;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root
{
    public interface IReadOnlyGameplay
    {
        ReadOnlyReactiveProperty<int> CurrentMapId { get; }
        IReadOnlyObservableList<Map> Maps { get; }

        int CreateGlobalEntityId();
    }
}
