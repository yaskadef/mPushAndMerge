using UnityEngine.SceneManagement;
using R3;
using System.Collections;
using Assets.mPushAndMerge.Scripts.Utils.Coroutines;
using UnityEngine;
using Assets.mPushAndMerge.Scripts.Game.Common;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public Subject<Unit> LoadScene(string sceneName)
        {
            var endLoadingSubj = new Subject<Unit>();

            _coroutineRunner.StartCoroutine(Load(sceneName, endLoadingSubj));

            return endLoadingSubj;
        }

        private IEnumerator Load(string sceneName, Subject<Unit> endLoadingSubj)
        {
            yield return LoadSceneAsync(SceneNames.BOOT);
            if (sceneName != SceneNames.BOOT) 
                yield return LoadSceneAsync(sceneName);

            yield return new WaitForSeconds(1);

            endLoadingSubj.OnNext(Unit.Default);
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
