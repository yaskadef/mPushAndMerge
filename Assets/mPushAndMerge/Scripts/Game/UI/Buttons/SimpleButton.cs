using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.mPushAndMerge.Scripts.Game.UI.Buttons
{
    public abstract class SimpleButton : MonoBehaviour
    {
        [SerializeField] private Button _btn;

        private void OnEnable()
        {
            _btn.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _btn.onClick.RemoveListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}
