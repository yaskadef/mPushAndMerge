using System.Collections;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Utils.Coroutines
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
