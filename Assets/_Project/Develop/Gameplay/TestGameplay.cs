using System.Collections;
using System.Collections.Generic;
using Infrastructure.DI;
using UnityEngine;

namespace Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private bool _isRunning;

        public void Initialize(DIContainer container) {
            _container = container;
        }

        public void Run() {
            _isRunning = true;
        }

        public void Update() {
            if (_isRunning == false)
                return;

            // Debug.Log("TestGameplay is running");
        }
    }
}
