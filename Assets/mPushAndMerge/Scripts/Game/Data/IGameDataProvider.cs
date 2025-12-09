using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using R3;

namespace Assets.mPushAndMerge.Scripts.Game.Data
{
    public interface IGameDataProvider
    {
        public GameDataProxy GameData { get; }

        public Observable<GameDataProxy> LoadGameData();

        public void SaveGameData();
        public void ResetData();
    }
}
