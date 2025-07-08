using System.Collections;
using UnityEngine;

namespace Utilities.CoroutinesManagment
{

    public interface ICoroutinesPerformer
    {
        Coroutine StartPerform(IEnumerator coroutine);
        void StopPerform(Coroutine coroutine);
    }
}