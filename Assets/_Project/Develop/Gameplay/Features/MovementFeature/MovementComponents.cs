using Gameplay.EntitiesCore;
using UnityEngine;
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
}
