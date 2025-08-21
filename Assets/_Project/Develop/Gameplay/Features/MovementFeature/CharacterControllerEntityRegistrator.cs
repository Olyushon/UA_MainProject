using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Gameplay.Features.MovementFeature
{
    public class CharacterControllerEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity) {
            entity.AddCharacterController(GetComponent<CharacterController>());
        }
    }
}
