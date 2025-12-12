using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Game Settings/Entities/Mergeable/New Building Entity Settings")]
    public class BuildingSettings : MergeableEntitySettings<BuildingLevelSettings>
    {
    }
}
