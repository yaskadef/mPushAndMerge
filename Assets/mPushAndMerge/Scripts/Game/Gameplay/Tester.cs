using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Services;
using UnityEngine;
using Zenject;

public class Tester : MonoBehaviour
{
    [Inject] private BuildingService _buildingService;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _buildingService.PlaceBuilding(
                configId: "cottage",
                posX: 1,
                posY: -1,
                level: 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _buildingService.PlaceBuilding(
                configId: "cottage",
                posX: -1,
                posY: -1,
                level: 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _buildingService.PlaceBuilding(
                configId: "cottage",
                posX: 1,
                posY: 0,
                level: 3);
        }
    }
}
