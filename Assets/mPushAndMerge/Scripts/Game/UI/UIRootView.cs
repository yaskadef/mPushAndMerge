using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.UI
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private Transform _sceneUIContainer;
        [SerializeField] private GameObject _loadingScreen;

        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen()
        {
            if(!_loadingScreen.activeInHierarchy) 
                _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        public void AttachSceneUI(Transform sceneUI)
        {
            ClearSceneUI();

            sceneUI.SetParent(_sceneUIContainer, worldPositionStays: false);
        }

        private void ClearSceneUI()
        {
            int childsContainerCount = _sceneUIContainer.childCount;
            for (int i = 0; i < childsContainerCount; i++)
            {
                Destroy(_sceneUIContainer.GetChild(i).gameObject);
            }
        }
    }
}
