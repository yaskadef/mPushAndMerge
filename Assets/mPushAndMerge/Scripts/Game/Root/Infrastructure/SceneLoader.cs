using UnityEngine.SceneManagement;
using R3;
using System.Collections;
using Assets.mPushAndMerge.Scripts.Utils.Coroutines;
using UnityEngine;
using Assets.mPushAndMerge.Scripts.Game.Common;
using Zenject;
using Assets.mPushAndMerge.Scripts.Game.Gameplay.Root;
using System;

namespace Assets.mPushAndMerge.Scripts.Game.Root.Infrastructure
{
    public class SceneLoader
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ZenjectSceneLoader sceneLoader, ICoroutineRunner coroutineRunner)
        {
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
        }

        public Observable<Unit> LoadScene(string sceneName, GameplayEnterParams enterParams = null)
        {
            var endLoading = new Subject<Unit>();

            _coroutineRunner.StartCoroutine(Load(sceneName, endLoading, enterParams));

            return endLoading;
        }

        private IEnumerator Load(
            string sceneName, 
            Subject<Unit> endLoadingSubj, 
            SceneEnterParams enterParams = null)
        {
            yield return LoadSceneAsync(SceneNames.BOOT);
            
            if (sceneName != SceneNames.BOOT) 
                yield return LoadSceneAsync(sceneName, enterParams);

            //TODO yield return null;
            yield return new WaitForSeconds(1);

            endLoadingSubj.OnNext(Unit.Default);
        }

        private IEnumerator LoadSceneAsync(string sceneName, SceneEnterParams enterParams = null)
        {
            yield return _sceneLoader.LoadSceneAsync(sceneName, LoadSceneMode.Single, container =>
            {
                if (enterParams == null) return;

                container
                .Bind<SceneEnterParams>()
                .FromInstance(enterParams)
                .AsSingle();
            });
        }
    }
}
