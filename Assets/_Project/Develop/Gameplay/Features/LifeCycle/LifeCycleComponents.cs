using Gameplay.EntitiesCore;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.LifeCycle
{
    public class CurrentHealth: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxHealth: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsDead: IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class MustDie: IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class MustSelfRelease: IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class DeathProcessInitialTime: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class DeathProcessCurrentTime: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class InDeathProcess: IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}
