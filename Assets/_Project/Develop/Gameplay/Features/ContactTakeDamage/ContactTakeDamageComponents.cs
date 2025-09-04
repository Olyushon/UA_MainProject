using Gameplay.EntitiesCore;
using Utilities.Reactive;
namespace Gameplay.Features.ContactTakeDamage
{
    public class BodyContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}
