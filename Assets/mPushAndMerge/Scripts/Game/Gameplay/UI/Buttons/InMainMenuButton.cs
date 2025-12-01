using Assets.mPushAndMerge.Scripts.Game.Common;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States;
using Assets.mPushAndMerge.Scripts.Game.UI.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.UI.Buttons
{
    public class InMainMenuButton : SimpleButton
    {
        [Inject] private GameStateMachine _gameStateMachine;

        protected override void OnButtonClicked()
        {
            _gameStateMachine.Enter<MainMenuState, string>(SceneNames.MAIN_MENU);
        }
    }
}
