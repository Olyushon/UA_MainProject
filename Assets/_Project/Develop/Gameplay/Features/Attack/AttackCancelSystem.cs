using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.Attack
{
    public class AttackCancelSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveEvent _attackCanceledEvent;
        private ICompositeCondition _mustCancelAttack;

        public void OnInitialize(Entity entity)
        {
            _inAttackProcess = entity.InAttackProcess;
            _attackCanceledEvent = entity.AttackCanceledEvent;
            _mustCancelAttack = entity.MustCancelAttack;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            if (_mustCancelAttack.Evaluate()) {
                Debug.Log("Attack canceled");
                _inAttackProcess.Value = false;
                _attackCanceledEvent.Invoke();
            }
        }
    }
}
