using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable
{
    public abstract class MergeableEntitySettings<T> : EntitySettings where T : MergeableLevelSettings
    {
        [SerializeField] public List<T> Levels;
    }
}
