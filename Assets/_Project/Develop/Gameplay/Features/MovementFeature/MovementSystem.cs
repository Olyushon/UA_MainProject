using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.MovementFeature
{
    public class MovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private Entity _entity;

        public void OnInitialize(Entity entity)
        {
            _entity = entity;
        }

        public void OnUpdate(float deltaTime)
        {
            ReactiveVariable<Vector3> direction = _entity.GetComponent<MoveDirection>().Value;
            ReactiveVariable<float> speed = _entity.GetComponent<MoveSpeed>().Value;

            Vector3 velocity = direction.Value.normalized * speed.Value;

            Debug.Log("Применяемая скорость: " + velocity.ToString());
        }
    }
}