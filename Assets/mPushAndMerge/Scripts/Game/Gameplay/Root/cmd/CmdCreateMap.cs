using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd
{
    public class CmdCreateMap : ICommand
    {
        public readonly int MapId;

        public CmdCreateMap(int mapId)
        {
            MapId = mapId;
        }
    }
}
