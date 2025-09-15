using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.Attack
{
    public class AttackCooldownTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inAttackCooldown;

        private ReactiveEvent _endAttackEvent;
        private IDisposable _endAttackEventDisposable;

        public void OnInitialize(Entity entity)
        {
            _currentTime = entity.AttackCooldownCurrentTime;
            _initialTime = entity.AttackCooldownInitialTime;
            _inAttackCooldown = entity.InAttackCooldown;
            _endAttackEvent = entity.EndAttackEvent;

            _endAttackEventDisposable = _endAttackEvent.Subscribe(OnEndAttackEvent);
        }

        private void OnEndAttackEvent()
        {
            Debug.Log("Cooldown started");
            _currentTime.Value = _initialTime.Value;
            _inAttackCooldown.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (IsCooldownOver())
            {
                _inAttackCooldown.Value = false;
                Debug.Log("Cooldown over");
            }
        }

        private bool IsCooldownOver() => _currentTime.Value <= 0;

        public void OnDispose()
        {
            _endAttackEventDisposable?.Dispose();
        }
    }
}
