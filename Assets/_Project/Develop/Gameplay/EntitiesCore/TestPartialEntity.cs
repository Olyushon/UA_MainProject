using Gameplay.Common;
using Gameplay.Features.MovementFeature;
using UnityEngine;
using Utilities.Reactive;

namespace Gameplay.EntitiesCore
{
    public partial class Entity 
    {
        // public RigidbodyComponent RigidbodyC => GetComponent<RigidbodyComponent>();
        // public Rigidbody Rigidbody => RigidbodyC.Value;
        // public Entity AddRigidbody(Rigidbody rigidbody) => AddComponent(new RigidbodyComponent(){Value = rigidbody});

        // public MoveDirection MoveDirectionC => GetComponent<MoveDirection>();
        // public ReactiveVariable<Vector3> MoveDirection => MoveDirectionC.Value;
        // public Entity AddMoveDirection(ReactiveVariable<Vector3> direction) 
        //     => AddComponent(new MoveDirection(){Value = direction});
        // public Entity AddMoveDirection() 
        //     => AddComponent(new MoveDirection(){Value = new ReactiveVariable<Vector3>()});

        // public MoveSpeed MoveSpeedC => GetComponent<MoveSpeed>();
        // public ReactiveVariable<float> MoveSpeed => MoveSpeedC.Value;
        // public Entity AddMoveSpeed(ReactiveVariable<float> speed) 
        //     => AddComponent(new MoveSpeed(){Value = speed});
        // public Entity AddMoveSpeed() 
        //     => AddComponent(new MoveSpeed(){Value = new ReactiveVariable<float>()});
    }
}
