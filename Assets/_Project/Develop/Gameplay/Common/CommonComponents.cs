using Gameplay.EntitiesCore;
using UnityEngine;

namespace Gameplay.Common
{
    public class RigidbodyComponent: IEntityComponent
    {
        public Rigidbody Value;
    }
    
    public class TransformComponent: IEntityComponent
    {
        public Transform Value;
    }
}
