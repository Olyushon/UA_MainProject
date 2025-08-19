using System;
using System.Collections.Generic;
using Gameplay.EntitiesCore.Systems;

namespace Gameplay.EntitiesCore
{
    public class Entity : IDisposable
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new();

        private readonly List<IEntitySystem> _systems = new();
        private readonly List<IInitializableSystem> _initializableSystems = new();
        private readonly List<IUpdatableSystem> _updatableSystems = new();
        private readonly List<IDisposableSystem> _disposableSystems = new();

        private bool _isInitialized = false;

        public void Initialize() {
            foreach (IInitializableSystem system in _initializableSystems)
                system.OnInitialize(this);

            _isInitialized = true;
        }

        public void OnUpdate(float deltaTime) {
            if (_isInitialized == false)
                return;

            foreach (IUpdatableSystem system in _updatableSystems)
                system.OnUpdate(deltaTime);
        }

        public void Dispose() {
            foreach (IDisposableSystem system in _disposableSystems)
                system.OnDispose();

            _isInitialized = false;
        }

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

        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new InvalidOperationException($"System {system.GetType().ToString()} already added");

            _systems.Add(system);

            if (system is IInitializableSystem initializable) {
                _initializableSystems.Add(initializable);

                if (_isInitialized)
                    initializable.OnInitialize(this);
            }

            if (system is IUpdatableSystem updatable)
                _updatableSystems.Add(updatable);

            if (system is IDisposableSystem disposable)
                _disposableSystems.Add(disposable);

            return this;
        }
    }
}
