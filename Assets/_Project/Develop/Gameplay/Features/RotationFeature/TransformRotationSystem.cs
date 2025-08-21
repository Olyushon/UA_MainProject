using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.RotationFeature
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _rotationSpeed;
        private Transform _transform;

        public void OnInitialize(Entity entity)
        {
            _direction = entity.MoveDirection;
            _rotationSpeed = entity.RotationSpeed;
            _transform = entity.Transform;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_direction.Value.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_direction.Value);
                Quaternion rotation = Quaternion.RotateTowards(
                    _transform.rotation, 
                    targetRotation, 
                    _rotationSpeed.Value * deltaTime
                );
                
                _transform.rotation = rotation;
            }
        }
    }
}
