using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using ObservableCollections;
using System.Collections.ObjectModel;


namespace Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps
{
    public interface IReadOnlyMap
    {
        public int MapId { get; }
        IReadOnlyObservableList<Entity> Entities { get; }
    }
}
