using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;
        private Rigidbody _rigidbody;
        private ReactiveVariable<bool> _isDead;

        public void OnInitialize(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;

            _isDead = entity.IsDead;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                return;

            if (_rotationDirection.Value.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value);
                Quaternion rotation = Quaternion.RotateTowards(
                    _rigidbody.rotation, 
                    targetRotation, 
                    _rotationSpeed.Value * deltaTime
                );
                
                _rigidbody.MoveRotation(rotation);
            }
        }
    }
}

