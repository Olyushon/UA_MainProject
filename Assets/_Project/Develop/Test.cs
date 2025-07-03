using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.AssetsManagment;
using Utilities.CoroutinesManagment;
using Utilities.ConfigsManagment;


namespace Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private CoroutinesPerformer _coroutinesPerformerPrefab;

        private ResourcesLoader _resourcesLoader;
        private ICoroutinesPerformer _coroutinesPerformer;

        private void Awake()
        {
            _resourcesLoader = CreateResourcesLoader();
            _coroutinesPerformer = CreateCoroutinesPerformer();
        }

        private ResourcesLoader CreateResourcesLoader() 
            => new ResourcesLoader();

        private ICoroutinesPerformer CreateCoroutinesPerformer()
        {
            CoroutinesPerformer coroutinesPerformerPrefab = _resourcesLoader.Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Instantiate(_coroutinesPerformerPrefab);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _coroutinesPerformer.StartPerform(TestCoroutine());
            }
        }

        private IEnumerator TestCoroutine()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("TestCoroutine");
        }
    }
}