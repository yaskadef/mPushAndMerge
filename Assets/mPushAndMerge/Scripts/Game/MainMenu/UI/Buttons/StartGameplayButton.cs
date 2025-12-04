using Assets.mPushAndMerge.Scripts.Game.Common;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States;
using Assets.mPushAndMerge.Scripts.Game.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.MainMenu.UI.Buttons
{
    public class StartGameplayButton : SimpleButton
    {
        [SerializeField] private int _mapId;

        [Inject] private GameStateMachine _gameStateMachine;

        protected override void OnButtonClicked()
        {
            var gameplayEnterParams = new GameplayEnterParams(_mapId);
            _gameStateMachine.Enter<LoadGameplayState, GameplayEnterParams>(gameplayEnterParams);
        }
    }
}
