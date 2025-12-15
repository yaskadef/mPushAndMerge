using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.View;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private WorldGameplayRootBinder _worldRootBinder;
        [SerializeField] private SceneAttacherUI _attacherUI;

        public override void InstallBindings()
        {
            BindGameplayEntryPoint();
            BindServices();
            BindView();
            BindAttacherUI();
        }

        private void BindGameplayEntryPoint()
        {
            Container
                .BindInterfacesTo<GameplayEntryPoint>()
                .AsSingle()
                .NonLazy();
        }

        private void BindServices()
        {
            Container
                .Bind<IMapInitializer>()
                .To<MapInitializer>()
                .AsSingle();

            Container
                .Bind<BuildingService>()
                .AsSingle();
        }

        private void BindView()
        {
            Container
                .Bind<WorldGameplayRootViewModel>()
                .AsSingle();

            Container
                .Bind<WorldGameplayRootBinder>()
                .FromInstance(_worldRootBinder)
                .AsSingle();
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
