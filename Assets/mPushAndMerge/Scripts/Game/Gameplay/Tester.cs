using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using UnityEngine;
using Zenject;

public class Tester : MonoBehaviour
{
    [Inject] private ICommandProcessor _commandProcessor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var command = new CmdPlaceEntity(
                EntityType.Building, 
                configId: "cottage", 
                posX: 1, 
                posY: -1, 
                level: 1);

            _commandProcessor.Process(command);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var command = new CmdPlaceEntity(
                EntityType.Building, 
                configId: "cottage", 
                posX: -1, 
                posY: -1, 
                level: 2);

            _commandProcessor.Process(command);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var command = new CmdPlaceEntity(
                EntityType.Building, 
                configId: "cottage", 
                posX: 1, 
                posY: 0, 
                level: 3);

            _commandProcessor.Process(command);
        }
    }
}
