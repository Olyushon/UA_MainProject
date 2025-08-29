using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ICompositeCondition _mustDie;

        public void OnInitialize(Entity entity)
        {
            _isDead = entity.IsDead;
            _mustDie = entity.MustDie;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                return;
                
            if (_mustDie.Evaluate()) {
                _isDead.Value = true;
            }
        }
    }
}
