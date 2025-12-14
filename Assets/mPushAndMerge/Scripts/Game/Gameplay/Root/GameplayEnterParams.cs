using Assets.mPushAndMerge.Scripts.Game.Common;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEnterParams : SceneEnterParams
    {
        public int MapId { get; }

        public GameplayEnterParams(int mapId) : base(SceneNames.GAMEPLAY)
        {
            MapId = mapId;
        }
    }
}
