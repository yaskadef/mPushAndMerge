using Assets.mPushAndMerge.Scripts.Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.mPushAndMerge.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : IInitializable
    {
        private readonly SceneAttacherUI _attacherUI;

        public MainMenuEntryPoint(SceneAttacherUI attacherUI)
        {
            _attacherUI = attacherUI;
        }

        public void Initialize()
        {
            _attacherUI.AttachSceneUI();
        }
    }
}
