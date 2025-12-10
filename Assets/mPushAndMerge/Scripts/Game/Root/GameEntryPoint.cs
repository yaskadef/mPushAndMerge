using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Root
{
    public class GameEntryPoint : IInitializable
    {
        [Inject] private Game _game;

        public void Initialize()
        {
            RunGame();
        }

        private void RunGame()
        {
            _game.GameStateMachine.Enter<BootstrapState>();
        }
    }
}
