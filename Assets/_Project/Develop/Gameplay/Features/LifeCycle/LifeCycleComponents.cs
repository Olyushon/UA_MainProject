using Gameplay.EntitiesCore;
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
}
