using Gameplay.EntitiesCore;
using UnityEngine;

namespace Gameplay.Features.MovementFeature
{
    public class MoveDirection: IEntityComponent
    {
        public Vector3 Value;
    }

    public class MoveSpeed: IEntityComponent
    {
        public float Value;
    }

    public class RigidbodyComponent: IEntityComponent
    {
        public Rigidbody Value;
    }
}
