using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States
{
    public class GameplayLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameplayLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}
