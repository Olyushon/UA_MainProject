using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.Attack
{
    public class EndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackEvent;
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveVariable<float> _attackProcessInitialTime;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private IDisposable _timerDisposable;

        public void OnInitialize(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnCurrentTimeChanged);
        }

        private void OnCurrentTimeChanged(float arg1, float currentTime)
        {
            if (TimeIsDone(currentTime)) {
                Debug.Log("End attack");

                _inAttackProcess.Value = false;
                _endAttackEvent.Invoke();
            }
        }

        private bool TimeIsDone(float currentTime) => currentTime >= _attackProcessInitialTime.Value;

        public void OnDispose()
        {
            _timerDisposable?.Dispose();
        }
    }
}
