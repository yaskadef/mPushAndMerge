using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root;
using Assets.mPushAndMerge.Scripts.Game.UI;
using R3;
using System;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class LoadGameplayState : IPayloadedState<GameplayEnterParams>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIRootView _uiRoot;

        public LoadGameplayState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader,
            UIRootView uiRootView)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiRoot = uiRootView;
        }

        public void Enter(GameplayEnterParams payload)
        {
            _uiRoot.ShowLoadingScreen();

            _sceneLoader.LoadScene(payload.SceneName, payload).Subscribe(_ =>
            {
                _gameStateMachine.Enter<GameplayLoopState>();
            });
        }

        public void Exit()
        {

        }
    }
}
