using Gameplay.EntitiesCore;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.ApplyDamage
{
    public class TakeDamageRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }
    public class TakeDamageEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }
    public class CanApplyDamage : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}
