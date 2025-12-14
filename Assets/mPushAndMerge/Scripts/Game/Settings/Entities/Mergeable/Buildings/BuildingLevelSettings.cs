using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable.Buildings
{
    [CreateAssetMenu(fileName = "BuildingLevelSettings", menuName = "Game Settings/Entities/Mergeable/New Building Level Settings")]
    public class BuildingLevelSettings : MergeableLevelSettings
    {
        [SerializeField] public int BaseIncome; 
    }
}
