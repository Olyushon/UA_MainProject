using Gameplay.EntitiesCore;
using UnityEngine;
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
}