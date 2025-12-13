using UnityEngine;
using Zenject;


namespace Assets.mPushAndMerge.Scripts.Game.UI
{
    public class SceneAttacherUI : MonoBehaviour
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
            AttachSceneUI();
        }

        private void AttachSceneUI()
        {
            _uiRoot.AttachSceneUI(_sceneUI);
        }
    }
}
