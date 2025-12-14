using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Settings.Entities
{
    public abstract class EntitySettings : ScriptableObject 
    {
        [SerializeField] public EntityType Type;
        [SerializeField] public string ConfigId;
        [SerializeField] public string TitleLid;
        [SerializeField] public string DescriptionLid;
        [SerializeField] public string PrefabPath;
    }

}
