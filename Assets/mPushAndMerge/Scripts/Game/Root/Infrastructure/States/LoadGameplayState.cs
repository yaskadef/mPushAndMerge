using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root;
using Assets.mPushAndMerge.Scripts.Game.UI;
using R3;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class LoadGameplayState : IPayloadedState<GameplayEnterParams>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIRootView _uiRoot;
        private readonly SceneEnterParamsService _sceneEnterParamsService;

        public LoadGameplayState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader,
            UIRootView uiRootView,
            SceneEnterParamsService sceneEnterParamsService)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiRoot = uiRootView;
            _sceneEnterParamsService = sceneEnterParamsService;
        }

        public void Enter(GameplayEnterParams payload)
        {
            _uiRoot.ShowLoadingScreen();

            _sceneEnterParamsService.SceneEnterParams = payload;

            _sceneLoader.LoadScene(payload.SceneName).Subscribe(_ =>
            {
                _gameStateMachine.Enter<GameplayLoopState>();
                _uiRoot.HideLoadingScreen();
            });
        }

        public void Exit()
        {

        }
    }
}
