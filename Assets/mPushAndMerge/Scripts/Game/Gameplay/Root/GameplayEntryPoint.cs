using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.UI;
using UnityEngine;
using Zenject;
using R3;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _sceneUI;

        private UIRootView _uiRoot;
        private IGameDataProvider _gameDataProvider;

        [Inject]
        public void Construct(UIRootView uiRoot, IGameDataProvider gameDataProvider)
        {
            _uiRoot = uiRoot;
            _gameDataProvider = gameDataProvider;
        }

        private void Awake()
        {
            _gameDataProvider.LoadGameData().Subscribe(_ =>
            {
                AttachSceneUI();
            });
        }

        private void AttachSceneUI()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
