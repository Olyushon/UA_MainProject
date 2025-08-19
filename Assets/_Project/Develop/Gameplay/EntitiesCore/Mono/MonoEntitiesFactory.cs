using UnityEngine;
using Utilities.AssetsManagment;

namespace Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory
    {
        private readonly ResourcesLoader _resourcesLoader;

        public MonoEntitiesFactory(ResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path) {
            MonoEntity prefab = _resourcesLoader.Load<MonoEntity>(path);

            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Setup(entity);

            return viewInstance;
        }
    }
}
