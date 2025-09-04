using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.MovementFeature
{
    public class CharacterControllerMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _speed;
        private ReactiveVariable<bool> _isMoving;
        private CharacterController _characterController;

        public void OnInitialize(Entity entity)
        {
            _direction = entity.MoveDirection;
            _speed = entity.MoveSpeed;
            _isMoving = entity.IsMoving;
            _characterController = entity.CharacterController;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 movement = _direction.Value.normalized * _speed.Value * deltaTime;

            _isMoving.Value = movement.magnitude > 0.01f;
            
            _characterController.Move(movement);
        }
    }
}
