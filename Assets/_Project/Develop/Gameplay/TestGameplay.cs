using Gameplay.EntitiesCore;
using Gameplay.Features.MovementFeature;
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

            _testEntity = _entitiesFactory.CreateTestEntity(Vector3.zero);
        }

        public void Update() {
            if (_isRunning == false)
                return;

            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _testEntity.MoveDirection.Value = input;
        }
    }
}
