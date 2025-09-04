using System.Collections.Generic;
using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private List<Collider> _colliders;

        public override void Register(Entity entity)
        {
            entity.AddDisableCollidersOnDeath(_colliders);
        }
    }
}
