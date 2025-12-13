using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.UI;
using UnityEngine;
using Zenject;
using R3;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using System.Linq;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure.cmd;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root.cmd;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _sceneUI;

        private UIRootView _uiRoot;
        private IGameDataProvider _gameDataProvider;
        private GameplayMapInitializer _gameplayMapInitializer;

        [Inject]
        public void Construct(
            UIRootView uiRoot, 
            IGameDataProvider gameDataProvider,
            GameplayMapInitializer gameplayMapInitializer)
        {
            _uiRoot = uiRoot;
            _gameDataProvider = gameDataProvider;
            _gameplayMapInitializer = gameplayMapInitializer;
        }

        private void Awake()
        {
            _gameDataProvider.LoadGameData().Subscribe(data =>
            {
                AttachSceneUI();
                _gameplayMapInitializer.Initialize(data);
            });
        }

        private void AttachSceneUI()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
