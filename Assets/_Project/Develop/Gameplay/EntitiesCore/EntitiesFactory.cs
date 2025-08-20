using Gameplay.EntitiesCore.Mono;
using Gameplay.Features.MovementFeature;
using Infrastructure.DI;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateTestEntity(Vector3 position) {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TestEntity");

            entity
                .AddComponent(new MoveDirection(){Value = new ReactiveVariable<Vector3>(Vector3.forward)})
                .AddComponent(new MoveSpeed(){Value = new ReactiveVariable<float>(10f)});

            entity.AddSystem(new RigidbodyMovementSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}
