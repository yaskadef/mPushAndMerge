using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure
{
    public abstract class SceneEnterParams
    {
        public string SceneName { get; }

        public SceneEnterParams(string sceneName)
        {
            SceneName = sceneName;
        }

        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}
