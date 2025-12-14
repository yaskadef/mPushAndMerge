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
        private BuildingViewModel _viewModel;

        [Inject]
        public void Construct(BuildingViewModel buildingViewModel)
        {
            _viewModel = buildingViewModel;
        }

        private void Awake()
        {
            var position2D = _viewModel.Position.CurrentValue;

            transform.position = new Vector3(
                position2D.x * AppConstants.POSITION_COEF,
                AppConstants.POSITION_Y,
                position2D.y * AppConstants.POSITION_COEF);
        }
    }
}
