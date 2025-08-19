using System;
using System.Collections.Generic;

namespace Gameplay.EntitiesCore
{
    public class Entity
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new();

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : class, IEntityComponent {
            _components.Add(typeof(TComponent), component);

            return this; // Теперь можно добавлять компоненты цепочкой
        }

        public bool HasComponent<TComponent>() where TComponent : class, IEntityComponent {
            return _components.ContainsKey(typeof(TComponent));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : class, IEntityComponent {
            if (_components.TryGetValue(typeof(TComponent), out IEntityComponent findedObject)) {
                component = (TComponent)findedObject;
                return true;
            }

            component = null;
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : class, IEntityComponent {
            if (TryGetComponent(out TComponent component) == false)
                throw new InvalidOperationException($"Component {typeof(TComponent)} not found");

            return component;
        }

    }
}
