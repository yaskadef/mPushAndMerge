using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.States;

namespace Assets.mPushAndMerge.Scripts.Game.Root
{
    public class Game
    {
        public GameStateMachine GameStateMachine { get; }

        public Game(GameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }
    }
}
