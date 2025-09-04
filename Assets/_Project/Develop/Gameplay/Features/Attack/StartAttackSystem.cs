using System;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.Attack
{
    public class StartAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackRequest;
        private ReactiveEvent _startAttackEvent;
        private ReactiveVariable<bool> _inAttackProcess;
        private ICompositeCondition _canStartAttack;

        private IDisposable _startAttackRequestDisposable;

        public void OnInitialize(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _startAttackEvent = entity.StartAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _canStartAttack = entity.CanStartAttack;

            _startAttackRequestDisposable = _startAttackRequest.Subscribe(OnStartAttackRequest);
        }

        public void OnDispose()
        {
            _startAttackRequestDisposable?.Dispose();
        }

        private void OnStartAttackRequest()
        {
            if (_canStartAttack.Evaluate()) {
                _inAttackProcess.Value = true;
                _startAttackEvent.Invoke();
                Debug.Log("Start attack");
            }
            else
            {
                Debug.Log("Can't start attack");
            }
        }
    }
}
