using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.EntitiesCore
{
    public class CollidersRegistryService
    {
        private readonly Dictionary<Collider, Entity> _colliderToEntity = new();

        public void Register(Collider collider, Entity entity)
        {
            _colliderToEntity.Add(collider, entity);
        }

        public void Unregister(Collider collider)
        {
            _colliderToEntity.Remove(collider);
        }

        public Entity GetEntityBy(Collider collider)
        {
            if (_colliderToEntity.TryGetValue(collider, out Entity entity))
                return entity;

            return null;
        }
    }
}
