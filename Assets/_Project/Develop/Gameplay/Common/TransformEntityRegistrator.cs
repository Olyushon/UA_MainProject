using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Gameplay.Common
{
    public class TransformEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity) {
            entity.AddTransform(GetComponent<Transform>());
        }
    }
}
