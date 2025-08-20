using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Gameplay.Common
{
    public class RigidbodyEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity) {
            entity.AddComponent(new RigidbodyComponent(){Value = GetComponent<Rigidbody>()});
        }
    }
}
