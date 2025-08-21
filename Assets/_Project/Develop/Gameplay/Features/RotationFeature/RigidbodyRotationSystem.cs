using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _rotationSpeed;
        private Rigidbody _rigidbody;

        public void OnInitialize(Entity entity)
        {
            _direction = entity.MoveDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_direction.Value.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_direction.Value);
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

