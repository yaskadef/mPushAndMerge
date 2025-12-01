
using UnityEngine;
using R3;
using Assets.mPushAndMerge.Scripts.Game.Common;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            SetTargetFrameRate();
            SetSleepTimeoutNeverSleep();

            LoadMainMenuState();
        }

        public void Exit()
        {
            
        }

        private void SetTargetFrameRate()
        {
            Application.targetFrameRate = 60;
        }

        private void SetSleepTimeoutNeverSleep()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void LoadMainMenuState()
        {
            _gameStateMachine.Enter<MainMenuState, string>(SceneNames.MAIN_MENU);
        }
    }
}
