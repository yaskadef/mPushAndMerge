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
        private readonly IGameDataProvider _gameDataProvider;

        public LoadGameplayState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader,
            UIRootView uiRootView,
            IGameDataProvider gameDataProvider)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiRoot = uiRootView;
            _gameDataProvider = gameDataProvider;
        }

        public void Enter(GameplayEnterParams payload)
        {
            _uiRoot.ShowLoadingScreen();

            _sceneLoader.LoadScene(payload.SceneName).Subscribe(_ =>
            {
                LoadData(payload);
            });
        }

        private void LoadData(GameplayEnterParams enterParams)
        {
            _gameDataProvider.LoadGameData().Subscribe(_ =>
            {
                EnterGameplayLoopState(enterParams);
            });
        }

        private void EnterGameplayLoopState(GameplayEnterParams enterParams)
        {
            _gameStateMachine.Enter<GameplayLoopState, GameplayEnterParams>(enterParams);
        }

        public void Exit()
        {

        }
    }
}
