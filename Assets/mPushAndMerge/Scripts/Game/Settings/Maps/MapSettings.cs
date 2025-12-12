using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Maps
{ 
    [CreateAssetMenu(fileName = "MapSettings", menuName = "Game Settings/Maps/New MapSettings")]
    public class MapSettings : ScriptableObject
    {
        public int MapId;
        public MapInitialStateSettings InitialState;
    }
}
