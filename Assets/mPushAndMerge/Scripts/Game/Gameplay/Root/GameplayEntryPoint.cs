using Assets.mPushAndMerge.Scripts.Game.UI;
using UnityEngine;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _sceneUI;

        private UIRootView _uiRoot;

        [Inject]
        public void Construct(UIRootView uiRoot)
        {
            _uiRoot = uiRoot;
        }

        private void Awake()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
