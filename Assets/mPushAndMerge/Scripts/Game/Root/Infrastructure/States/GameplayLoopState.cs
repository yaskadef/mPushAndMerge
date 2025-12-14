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
    public class GameplayLoopState : IPayloadedState<GameplayEnterParams>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IMapInitializer _mapInitializer;
        private readonly UIRootView _uiRoot;

        public GameplayLoopState(
            GameStateMachine gameStateMachine,
            UIRootView uiRoot,
            IMapInitializer mapInitializer)
        {
            _gameStateMachine = gameStateMachine;
            _mapInitializer = mapInitializer;
            _uiRoot = uiRoot;
        }


        public void Enter(GameplayEnterParams payload)
        {
            _mapInitializer.Initialize(payload.MapId);
            _uiRoot.HideLoadingScreen();
        }

        public void Exit()
        {

        }
    }
}
