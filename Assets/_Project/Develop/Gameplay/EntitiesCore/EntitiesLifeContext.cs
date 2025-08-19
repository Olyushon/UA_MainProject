using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.EntitiesCore
{
    public class EntitiesLifeContext : IDisposable
    {
        public event Action<Entity> Added;
        public event Action<Entity> Released;

        private readonly List<Entity> _entities = new();
        private readonly List<Entity> _releaseRequests = new();

        public void Add(Entity entity) {
            _entities.Add(entity);

            entity.Initialize();

            Added?.Invoke(entity);
        }

        public void Update(float deltaTime) {
            for (var i = 0; i < _entities.Count; i++) //Тк в процессе может добавиться новый элемент, и for его корректно обработает, в отличии от foreach
                _entities[i].OnUpdate(deltaTime);

            foreach (Entity entity in _releaseRequests) { //Освобождаем и удаляем из списка сущности - только после всех апдейтов
                _entities.Remove(entity);
                entity.Dispose();

                Released?.Invoke(entity);
            }

            _releaseRequests.Clear();
        }

        public void Release(Entity entity) {
            _releaseRequests.Add(entity);
        }

        public void Dispose() {
            foreach (Entity entity in _entities)
                entity.Dispose();

            _entities.Clear();
            _releaseRequests.Clear();
        }
    }
}
