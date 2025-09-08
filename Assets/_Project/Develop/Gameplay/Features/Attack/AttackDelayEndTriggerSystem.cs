using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _attackDelayEndEvent;
        private ReactiveVariable<float> _delay;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private ReactiveEvent _startAttackEvent;

        private bool _alreadyAttacked;

        private IDisposable _timerDisposable;
        private IDisposable _startAttackEventDisposable;

        public void OnInitialize(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _delay = entity.AttackDelayTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _startAttackEvent = entity.StartAttackEvent;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
            _startAttackEventDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (_alreadyAttacked)
                return;

            if (currentTime >= _delay.Value) {
                Debug.Log("Attack delay end");
                _attackDelayEndEvent.Invoke();
                _alreadyAttacked = true;
            }
        }

        private void OnStartAttack()
        {
            _alreadyAttacked = false;
        }

        public void OnDispose()
        {
            _timerDisposable?.Dispose();
            _startAttackEventDisposable?.Dispose();
        }
    }
}
