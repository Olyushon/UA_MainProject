using Gameplay.EntitiesCore;
using Utilities.Reactive;

namespace Gameplay.Features.RotationFeature
{
    public class RotationSpeed: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}