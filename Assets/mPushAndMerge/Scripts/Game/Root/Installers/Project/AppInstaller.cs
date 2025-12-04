using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States;
using Assets.mPushAndMerge.Scripts.Game.UI;
using Assets.mPushAndMerge.Scripts.Utils.Coroutines;
using System;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Installers.Project
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private Coroutines _coroutines;
        [SerializeField] private UIRootView _uiRootView;

        public override void InstallBindings()
        {
            BindGameEntryPoint();
            
            BindGame();
            BindStates();
            BindServices();

            BindCoroutines();
            BindUIRoot();
        }

        private void BindUIRoot()
        {
            Container
                .Bind<UIRootView>()
                .FromInstance(_uiRootView)
                .AsSingle();
        }

        private void BindCoroutines()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(_coroutines)
                .AsSingle();
        }

        private void BindServices()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindGameEntryPoint()
        {
            Container
                .BindInterfacesAndSelfTo<GameEntryPoint>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGame()
        {
            Container
                .Bind<Game>()
                .AsSingle();
        }

        private void BindStates()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle();
        }
    }
}
