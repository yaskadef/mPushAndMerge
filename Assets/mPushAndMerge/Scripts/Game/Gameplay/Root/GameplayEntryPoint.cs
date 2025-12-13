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
        private GameplayEnterParams _enterParams;
        private ICommandProcessor _commandProcessor;

        [Inject]
        public void Construct(
            UIRootView uiRoot, 
            IGameDataProvider gameDataProvider,
            SceneEnterParamsService sceneEnterParamsService,
            ICommandProcessor commandProcessor)
        {
            _uiRoot = uiRoot;
            _gameDataProvider = gameDataProvider;

            if(sceneEnterParamsService.SceneEnterParams is GameplayEnterParams enterParams)
                _enterParams = enterParams;

            _commandProcessor = commandProcessor;
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
            if (_enterParams == null) 
                _enterParams = new GameplayEnterParams(mapId:0);

            gameDataProxy.CurrentMapId.Value = _enterParams.MapId;
            
            var loadedMap = gameDataProxy.Maps.FirstOrDefault(m => m.MapId == _enterParams.MapId);
            if (loadedMap == null)
            {
                Debug.Log("Creating map from settings.");
                var command = new CmdCreateMap(_enterParams.MapId);
                _commandProcessor.Process(command);

                loadedMap = gameDataProxy.Maps.First(m => m.MapId == _enterParams.MapId);
            }
            else
            {
                Debug.Log("Map loaded from PlayerPrefs!");
            }


        }

        private void AttachSceneUI()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
