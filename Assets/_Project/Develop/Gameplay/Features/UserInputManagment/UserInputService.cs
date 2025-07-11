using System;
using UnityEngine;

namespace Gameplay.Features.UserInputManagment
{
    public class UserInputService
    {
        public event Action<string> OnSequenceInputReceived;

        private KeyCode _enterKey;
        private string _currentSequence = "";
        private bool _isActive = false;

        public UserInputService() {
        }

        public void On() {
            _isActive = true;
        }

        public void Off() {
            _isActive = false;
        }

        public void SetEnterKey(KeyCode enterKey) {
            _enterKey = enterKey;
        }

        public void Update(float deltaTime) {
            if (_isActive == false)
                return;

            if (Input.anyKeyDown) {
                if (Input.GetKeyDown(_enterKey) && string.IsNullOrEmpty(_currentSequence) == false) {
                    OnSequenceInputReceived?.Invoke(_currentSequence);
                    ResetSequence();
                }

                string input = Input.inputString;

                if (string.IsNullOrEmpty(input) == false) {
                    _currentSequence += input;
                }
            }
        }

        public void ResetSequence() {
            _currentSequence = "";
        }
    }
}
