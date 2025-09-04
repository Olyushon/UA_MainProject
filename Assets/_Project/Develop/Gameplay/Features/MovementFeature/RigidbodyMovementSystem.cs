using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.MovementFeature
{
    public class RigidbodyMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _speed;
        private Rigidbody _rigidbody;
        private ReactiveVariable<bool> _isMoving;
        private ICompositeCondition _canMove;

        public void OnInitialize(Entity entity)
        {
            _direction = entity.MoveDirection;
            _speed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;
            _isMoving = entity.IsMoving;

            _canMove = entity.CanMove;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canMove.Evaluate() == false) {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = _direction.Value.normalized * _speed.Value;

            _isMoving.Value = velocity.magnitude > 0.01f;
            
            _rigidbody.velocity = velocity;
        }
    }
}