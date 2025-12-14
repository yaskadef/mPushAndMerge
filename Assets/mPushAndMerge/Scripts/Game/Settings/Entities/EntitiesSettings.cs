using Assets.mPushAndMerge.Scripts.Game.Settings.Entities.Mergeable.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities
{
    [CreateAssetMenu(fileName = "EntitiesSettings", menuName = "Game Settings/Entities/New EntitiesSettings")]
    public class EntitiesSettings : ScriptableObject
    {
        public List<BuildingSettings> Buildings;
    }
}
