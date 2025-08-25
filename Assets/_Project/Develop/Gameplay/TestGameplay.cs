using Gameplay.EntitiesCore;
using Infrastructure.DI;
using UnityEngine;

namespace Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private bool _isRunning;
        private Entity _testEntity;

        public void Initialize(DIContainer container) {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run() {
            _isRunning = true;

            // _testEntity = _entitiesFactory.CreateRigidbodyTestEntity(Vector3.zero);
            // _testEntity = _entitiesFactory.CreateCharacterControllerTestEntity(Vector3.zero);
            _testEntity = _entitiesFactory.CreateGhostEntity(Vector3.zero);
        }

        public void Update() {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space)) {
                _testEntity.CurrentHealth.Value -= 50;
                Debug.Log("CurrentHealth: " + _testEntity.CurrentHealth.Value);
            }

            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _testEntity.MoveDirection.Value = input;
            _testEntity.RotationDirection.Value = input;
        }
    }
}
