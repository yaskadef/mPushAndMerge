using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using R3;
using System;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : IInitializable
    {
        private readonly IGameDataProvider _dataProvider;
        private readonly IMapInitializer _mapInitializer;
        private readonly GameplayEnterParams _enterParams;


        public GameplayEntryPoint(
            IGameDataProvider dataProvider, 
            IMapInitializer mapInitializer,
            SceneEnterParams p)
        {
            _dataProvider = dataProvider;
            _mapInitializer = mapInitializer;

            if (p is not GameplayEnterParams enterParams)
                throw new InvalidOperationException("GameplayEntryPoint requires GameplayEnterParams");

            _enterParams = enterParams;
        }

        public void Initialize()
        {
            _dataProvider.LoadGameData().Subscribe(data =>
            {
                _mapInitializer.Initialize(_enterParams.MapId);
            });
        }
    }
}
