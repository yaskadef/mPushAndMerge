using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.Installers
{
    public class EntryServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMapInstaller();
        }

        private void BindMapInstaller()
        {
            Container.Bind<GameplayMapInitializer>().AsSingle();
        }
    }
}
