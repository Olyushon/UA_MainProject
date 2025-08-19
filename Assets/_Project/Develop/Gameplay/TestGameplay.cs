using System.Collections;
using System.Collections.Generic;
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

        public void Initialize(DIContainer container) {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run() {
            _isRunning = true;

            Entity testEntity = _entitiesFactory.CreateTestEntity();

            Debug.Log("Направление движения: " + testEntity.GetComponent<MoveDirection>().Value.Value.ToString());
            Debug.Log("Скорость движения: " + testEntity.GetComponent<MoveSpeed>().Value.Value.ToString());
        }

        public void Update() {
            if (_isRunning == false)
                return;

            // Debug.Log("TestGameplay is running");
        }
    }
}
