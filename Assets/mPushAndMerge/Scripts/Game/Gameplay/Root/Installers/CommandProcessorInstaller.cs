using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd.Handlers;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.Installers
{
    public class CommandProcessorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCommandProcessor();
            BindHandlers();
            BindCommandRegistrar();
        }

        private void BindCommandProcessor()
        {
            Container
                .Bind<ICommandProcessor>()
                .To<CommandProcessor>()
                .AsSingle();
        }

        private void BindHandlers()
        {
            Container
                .Bind<ICommandHandler<CmdPlaceEntity>>()
                .To<HandlerPlaceEntity>()
                .AsSingle();
        }

        private void BindCommandRegistrar()
        {
            Container.Bind<CommandRegistrar>().AsSingle().NonLazy();
        }
    }
}
