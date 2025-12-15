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
            var command = new CmdPlaceEntity(EntityType.Building, "cottage", 1,1, 1);
            _commandProcessor.Process(command);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var command = new CmdPlaceEntity(EntityType.Building, "cottage", 2, 2, 2);
            _commandProcessor.Process(command);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var command = new CmdPlaceEntity(EntityType.Building, "cottage", -1, -1, 3);
            _commandProcessor.Process(command);
        }
    }
}
