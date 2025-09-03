using System;
using System.Collections.Generic;
using Infrastructure.DI;
using UnityEngine;
using Utilities.AssetsManagment;
using Object = UnityEngine.Object;

namespace Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory : IInitializable, IDisposable
    {
        private readonly ResourcesLoader _resourcesLoader;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly CollidersRegistryService _collidersRegistryService;
        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new();

        public MonoEntitiesFactory(
            ResourcesLoader resourcesLoader, 
            EntitiesLifeContext entitiesLifeContext,
            CollidersRegistryService collidersRegistryService)
        {
            _resourcesLoader = resourcesLoader;
            _entitiesLifeContext = entitiesLifeContext;
            _collidersRegistryService = collidersRegistryService;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path) {
            MonoEntity prefab = _resourcesLoader.Load<MonoEntity>(path);

            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Initialize(_collidersRegistryService);
            viewInstance.Link(entity);

            _entityToMono.Add(entity, viewInstance);

            return viewInstance;
        }

        public void Initialize() {
            _entitiesLifeContext.Released += OnEntityReleased;
        }

        public void Dispose() {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (Entity entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }

        private void OnEntityReleased(Entity entity) {
            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }

        private void CleanupFor(Entity entity) {
            MonoEntity viewInstance = _entityToMono[entity];
            viewInstance.Cleanup(entity);
            Object.Destroy(viewInstance.gameObject);
        }
    }
}
