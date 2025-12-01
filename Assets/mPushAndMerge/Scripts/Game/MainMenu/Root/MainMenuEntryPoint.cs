using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _mainMenuUI;

        private UIRootView _rootView;

        [Inject]
        public void Construct(UIRootView uiRoot)
        {
            _rootView = uiRoot;
        }

        private void Awake()
        {
            _rootView.AttachSceneUI(_mainMenuUI);
        }
    }
}
