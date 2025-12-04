using Assets.mPushAndMerge.Scripts.Game.UI;
using R3;
using TMPro.EditorUtilities;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class MainMenuState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIRootView _uiRoot;

        public MainMenuState(
            GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader, 
            UIRootView uiRoot)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiRoot = uiRoot;
        }

        public void Enter(string payload)
        {
            _uiRoot.ShowLoadingScreen();

            _sceneLoader.LoadScene(payload).Subscribe(_ =>
            {
                _uiRoot.HideLoadingScreen();
            });
        }

        public void Exit()
        {

        }
    }
}
