using Assets.mPushAndMerge.Scripts.Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingBinder : MonoBehaviour
    {
        public void Bind(BuildingViewModel buildingViewModel)
        {
            var position2D = buildingViewModel.Position.CurrentValue;

            transform.position = new Vector3(
                position2D.x * AppConstants.POSITION_COEF,
                AppConstants.POSITION_Y,
                position2D.y * AppConstants.POSITION_COEF);
        }
    }
}
