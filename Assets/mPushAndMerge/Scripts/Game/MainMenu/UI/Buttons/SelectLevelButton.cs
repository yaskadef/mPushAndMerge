using Assets.mPushAndMerge.Scripts.Game.UI.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.mPushAndMerge.Scripts.Game.MainMenu.UI.Buttons
{
    public class SelectLevelButton : SimpleButton
    {
        [SerializeField] private GameObject _menuButtonsContainer;
        [SerializeField] private GameObject _levelButtonsContainer;

        protected override void OnButtonClicked()
        {
            _menuButtonsContainer.SetActive(false);
            _levelButtonsContainer.SetActive(true);
        }
    }
}
