using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.View;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using System;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameplayEntryPoint();
            BindServices();
            BindView();
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
        }

    }
}
