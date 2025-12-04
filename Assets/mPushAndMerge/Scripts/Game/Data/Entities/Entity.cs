using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Data.Entities
{
    public class Entity : IReadOnlyEntity
    {
        public EntityData Origin { get;}

        public readonly ReactiveProperty<Vector2Int> Position;

        public Entity(EntityData entityData)
        {
            Origin = entityData;

            Position = new ReactiveProperty<Vector2Int>(
                new Vector2Int(
                    entityData.PositionX, 
                    entityData.PositionY
                )
            );


        }

        public int UniqueId => Origin.UniqueId;

        public string ConfigId => Origin.ConfigId;

        public EntityType EntityType => Origin.EntityType;

        ReadOnlyReactiveProperty<Vector2Int> IReadOnlyEntity.Position => Position;
    }
}
