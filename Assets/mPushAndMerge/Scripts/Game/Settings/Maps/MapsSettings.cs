using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Maps
{
    [CreateAssetMenu(fileName = "MapsSettings", menuName = "Game Settings/Maps/New MapsSettings")]
    public class MapsSettings : ScriptableObject
    {
        public List<MapSettings> MapSettings;
    }
}
