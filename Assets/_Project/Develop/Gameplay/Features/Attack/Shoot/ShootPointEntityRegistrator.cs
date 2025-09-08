using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Gameplay.Features.Attack.Shoot
{
    public class ShootPointEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _shootPoint;

        public override void Register(Entity entity)
        {
            entity.AddShootPoint(_shootPoint);
        }
    }
}
