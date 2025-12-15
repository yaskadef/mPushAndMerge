using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using R3;
using System;
using Zenject;
using UnityEngine;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.View;
using Assets.mPushAndMerge.Scripts.Game.UI;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : IInitializable
    {
        private readonly IGameDataProvider _dataProvider;
        private readonly IMapInitializer _mapInitializer;
        private readonly GameplayEnterParams _enterParams;
        private readonly WorldGameplayRootBinder _worldRootBinder;
        private readonly SceneAttacherUI _sceneAttacherUI;

        public GameplayEntryPoint(
            IGameDataProvider dataProvider, 
            IMapInitializer mapInitializer,
            WorldGameplayRootBinder worldRootBinder,
            SceneAttacherUI sceneAttacherUI,
            SceneEnterParams p)
        {
            _dataProvider = dataProvider;
            _mapInitializer = mapInitializer;
            _worldRootBinder = worldRootBinder;
            _sceneAttacherUI = sceneAttacherUI;

            if (p is not GameplayEnterParams enterParams)
                throw new InvalidOperationException("GameplayEntryPoint requires GameplayEnterParams");

            _enterParams = enterParams;
        }

        public void Initialize()
        {
            _sceneAttacherUI.AttachSceneUI();
            _worldRootBinder.InitWorldView();

            _dataProvider.LoadGameData().Subscribe(data =>
            {
                _mapInitializer.Initialize(_enterParams.MapId);
            });
        }
    }
}
