using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
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
    }
}
