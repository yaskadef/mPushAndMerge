using Assets.mPushAndMerge.Scripts.Game.Data;
using Assets.mPushAndMerge.Scripts.Game.UI;
using UnityEngine;
using Zenject;
using R3;
using Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure;
using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using System.Linq;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _sceneUI;

        private UIRootView _uiRoot;
        private IGameDataProvider _gameDataProvider;
        private GameplayEnterParams _enterParams;

        [Inject]
        public void Construct(
            UIRootView uiRoot, 
            IGameDataProvider gameDataProvider,
            SceneEnterParamsService sceneEnterParamsService)
        {
            _uiRoot = uiRoot;
            _gameDataProvider = gameDataProvider;

            if(sceneEnterParamsService.SceneEnterParams is GameplayEnterParams enterParams)
                _enterParams = enterParams;
        }

        private void Awake()
        {
            _gameDataProvider.LoadGameData().Subscribe(data =>
            {
                AttachSceneUI();
                CreateMap(data);
            });
        }

        private void CreateMap(GameDataProxy gameDataProxy)
        {
            if (_enterParams == null) _enterParams = new GameplayEnterParams(mapId:0);
            var loadedMap = gameDataProxy.Maps.FirstOrDefault(m => m.MapId == _enterParams.MapId);
            if (loadedMap == null)
            {

            }
        }

        private void AttachSceneUI()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
