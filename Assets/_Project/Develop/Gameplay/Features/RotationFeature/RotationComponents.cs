using Gameplay.EntitiesCore;
using UnityEngine;
using Utilities.Conditions;
using Utilities.Reactive;

namespace Gameplay.Features.RotationFeature
{
    public class RotationDirection: IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
    public class RotationSpeed: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanRotate: IEntityComponent
    {
        public ICompositeCondition Value;
    }
}