using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using ObservableCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps
{
    public interface IMapPlacement
    {
        public IObservableCollection<Entity> Entities { get; }

        public bool IsPositionAvailable(int x, int y);
    }
}
