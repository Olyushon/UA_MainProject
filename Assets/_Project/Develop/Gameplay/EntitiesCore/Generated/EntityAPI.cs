namespace Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Gameplay.Features.RotationFeature.RotationSpeed RotationSpeedC => GetComponent<Gameplay.Features.RotationFeature.RotationSpeed>();

		public Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Gameplay.Features.RotationFeature.RotationSpeed() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddRotationSpeed(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.RotationFeature.RotationSpeed() {Value = value}); 
		}

		public Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<Gameplay.Features.MovementFeature.MoveDirection>();

		public Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Gameplay.Features.MovementFeature.MoveDirection() { Value = new Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddMoveDirection(Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<Gameplay.Features.MovementFeature.MoveSpeed>();

		public Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Gameplay.Features.MovementFeature.MoveSpeed() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddMoveSpeed(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public Gameplay.Features.MovementFeature.CharacterControllerComponent CharacterControllerC => GetComponent<Gameplay.Features.MovementFeature.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.CharacterControllerComponent() {Value = value}); 
		}

		public Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public Gameplay.Common.TransformComponent TransformC => GetComponent<Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
