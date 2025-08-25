using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _currentHealth;
        private ReactiveVariable<bool> _isDead;

        public void OnInitialize(Entity entity)
        {
            _currentHealth = entity.CurrentHealth;
            _isDead = entity.IsDead;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                return;
                
            if (_currentHealth.Value <= 0) {
                _isDead.Value = true;
                Debug.Log("Dead");
            }
        }
    }
}
