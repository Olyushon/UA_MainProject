using System;
using System.Collections.Generic;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathSystem : IInitializableSystem, IDisposableSystem
    {
        private List<Collider> _colliders;
        private ReactiveVariable<bool> _isDead;

        private IDisposable _isDeadChangeDisposable;

        public void OnInitialize(Entity entity)
        {
            _colliders = entity.DisableCollidersOnDeath;
            _isDead = entity.IsDead;

            _isDeadChangeDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnDispose()
        {
            _isDeadChangeDisposable?.Dispose();
        }

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead)
                foreach (Collider collider in _colliders)
                    collider.enabled = false;
        }
    }
}
