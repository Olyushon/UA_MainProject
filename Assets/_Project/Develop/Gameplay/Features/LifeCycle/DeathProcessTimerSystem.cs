using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using Utilities.Reactive;

namespace Gameplay.Features.LifeCycle
{
    public class DeathProcessTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<bool> _inDeathProcess;
        private ReactiveVariable<bool> _isDead;

        private IDisposable _isDeadChangeDisposable;

        public void OnInitialize(Entity entity)
        {
            _initialTime = entity.DeathProcessInitialTime;
            _currentTime = entity.DeathProcessCurrentTime;
            _inDeathProcess = entity.InDeathProcess;
            _isDead = entity.IsDead;

            _isDeadChangeDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inDeathProcess.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (IsCooldownOver())
                _inDeathProcess.Value = false;
        }

        public void OnDispose()
        {
            _isDeadChangeDisposable?.Dispose();
        }

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead) {
                _inDeathProcess.Value = true;
                _currentTime.Value = _initialTime.Value;
            }
        }

        private bool IsCooldownOver() => _currentTime.Value <= 0;
    }
}
