using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root;
using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class GameplayLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIRootView _uiRoot;

        public GameplayLoopState(
            GameStateMachine gameStateMachine,
            UIRootView uiRoot)
        {
            _gameStateMachine = gameStateMachine;
            _uiRoot = uiRoot;
        }

        public void Enter()
        {
            _uiRoot.HideLoadingScreen();
        }

        public void Exit()
        {

        }
    }
}
