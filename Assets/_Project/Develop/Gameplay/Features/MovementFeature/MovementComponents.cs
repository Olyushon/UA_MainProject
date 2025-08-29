using Gameplay.EntitiesCore;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.MovementFeature
{
    public class MoveDirection: IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanMove: IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class CharacterControllerComponent : IEntityComponent
    {
        public CharacterController Value;
    }
}
