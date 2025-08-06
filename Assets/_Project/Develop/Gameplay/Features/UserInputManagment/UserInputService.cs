using System;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.UserInputManagment
{
    public class UserInputService
    {
        public event Action<string> OnSequenceInputReceived;

        private KeyCode _enterKey;
        private ReactiveVariable<string> _currentSequence = new ReactiveVariable<string>("");
        private bool _isActive = false;

        public UserInputService() {
        }

        public IReadOnlyVariable<string> CurrentSequence => _currentSequence;

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
                if (Input.GetKeyDown(_enterKey) && string.IsNullOrEmpty(_currentSequence.Value) == false) {
                    OnSequenceInputReceived?.Invoke(_currentSequence.Value);
                    // ResetSequence();
                }

                string input = Input.inputString;

                if (string.IsNullOrEmpty(input) == false) {
                    _currentSequence.Value += input;
                }
            }
        }

        public void ResetSequence() {
            _currentSequence.Value = "";
        }
    }
}
