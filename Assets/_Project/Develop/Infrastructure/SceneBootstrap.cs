using System.Collections;
using UnityEngine;
using Infrastructure.DI;
using Utilities.SceneManagment;

namespace Infrastructure
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null);

        public abstract IEnumerator Initialize();

        public abstract void Run();
    }
}