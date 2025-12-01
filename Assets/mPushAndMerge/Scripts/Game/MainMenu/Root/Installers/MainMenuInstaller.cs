using Assets.mPushAndMerge.Scripts.Game.MainMenu.Root;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Root.MainMenu.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        //[SerializeField] private MainMenuEntryPoint _mainMenuEntryPoint;

        public override void InstallBindings()
        {
            //BindEntryPoint();
        }

        private void BindEntryPoint()
        {
            //Container.BindInterfacesAndSelfTo<MainMenuEntryPoint>().AsSingle().NonLazy();
        }
    }
}
