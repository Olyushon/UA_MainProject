using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.MovementFeature
{
    public class RigidbodyMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _speed;
        private Rigidbody _rigidbody;
        private ReactiveVariable<bool> _isDead;

        public void OnInitialize(Entity entity)
        {
            _direction = entity.MoveDirection;
            _speed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;

            _isDead = entity.IsDead;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value) {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = _direction.Value.normalized * _speed.Value;
            
            _rigidbody.velocity = velocity;
        }
    }
}