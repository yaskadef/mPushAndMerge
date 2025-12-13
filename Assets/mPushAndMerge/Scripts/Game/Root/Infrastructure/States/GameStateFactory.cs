using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class GameStateFactory
    {
        private readonly DiContainer _container;

        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>() where T : IExitableState
        {
            return _container.Instantiate<T>();
        }
    }
}
