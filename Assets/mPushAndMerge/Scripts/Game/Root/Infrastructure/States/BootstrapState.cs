
using UnityEngine;
using R3;
using Assets.mPushAndMerge.Scripts.Game.Common;
using Assets.mPushAndMerge.Scripts.Game.Settings;
using Assets.mPushAndMerge.Scripts.Game.UI;
using Assets.mPushAndMerge.Scripts.Utils.JsonSerialization;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIRootView _uiRoot;
        private readonly ISettingsProvider _settingsProvider;

        public BootstrapState(
            GameStateMachine stateMachine,
            UIRootView uiRoot,
            ISettingsProvider settingsProvider)
        {
            _gameStateMachine = stateMachine;
            _settingsProvider = settingsProvider;
            _uiRoot = uiRoot;
        }

        public async void Enter()
        {
            _uiRoot.ShowLoadingScreen();

            SetTargetFrameRate();
            SetSleepTimeoutNeverSleep();

            JsonProjectSettings.ApplyJsonEntityConverterSettings();

            await _settingsProvider.LoadGameSettings();

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
