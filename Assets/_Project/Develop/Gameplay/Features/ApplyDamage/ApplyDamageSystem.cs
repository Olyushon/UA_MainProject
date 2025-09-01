using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.ApplyDamage
{       
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _takeDamageRequest;
        private ReactiveEvent<float> _takeDamageEvent;

        private ReactiveVariable<float> _health;

        private ICompositeCondition _canApplyDamage;

        private IDisposable _requestDisposable;

        public void OnInitialize(Entity entity)
        {
            _takeDamageRequest = entity.TakeDamageRequest;
            _takeDamageEvent = entity.TakeDamageEvent;
            _health = entity.CurrentHealth;
            _canApplyDamage = entity.CanApplyDamage;

            _requestDisposable = _takeDamageRequest.Subscribe(OnTakeDamageRequest);
        }

        public void OnDispose()
        {
            _requestDisposable?.Dispose();
        }

        private void OnTakeDamageRequest(float damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_canApplyDamage.Evaluate() == false)
                return;

            _health.Value = Mathf.Max(_health.Value - damage, 0);

            _takeDamageEvent.Invoke(damage);

            Debug.Log($"Took {damage} damage, current health: {_health.Value}");
        }
    }
}
