using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities
{
    public class EntityData
    {
        public int UniqueId { get; set; }
        public string ConfigId { get; set; }
        public EntityType EntityType { get; set; }
        public int Level { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
