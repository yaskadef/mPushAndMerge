using Assets.mPushAndMerge.Scripts.Game.MainMenu.Root;
using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Root.MainMenu.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private SceneAttacherUI _attacherUI;

        public override void InstallBindings()
        {
            BindMainMenuEntryPoint();
            BindAttacherUI();
        }

        private void BindMainMenuEntryPoint()
        {
            Container
                .BindInterfacesTo<MainMenuEntryPoint>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAttacherUI()
        {
            Container
                .Bind<SceneAttacherUI>()
                .FromInstance(_attacherUI)
                .AsSingle();
        }
    }
}
