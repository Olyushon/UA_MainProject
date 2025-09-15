namespace Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Utilities.Buffer<Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Utilities.Buffer<Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public Gameplay.Features.RotationFeature.RotationDirection RotationDirectionC => GetComponent<Gameplay.Features.RotationFeature.RotationDirection>();

		public Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Gameplay.Features.RotationFeature.RotationDirection() { Value = new Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddRotationDirection(Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Gameplay.Features.RotationFeature.RotationDirection() {Value = value}); 
		}

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

		public Gameplay.Features.RotationFeature.CanRotate CanRotateC => GetComponent<Gameplay.Features.RotationFeature.CanRotate>();

		public Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public Gameplay.EntitiesCore.Entity AddCanRotate(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.RotationFeature.CanRotate() {Value = value}); 
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

		public Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<Gameplay.Features.MovementFeature.IsMoving>();

		public Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Gameplay.Features.MovementFeature.IsMoving() { Value = new Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddIsMoving(Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.IsMoving() {Value = value}); 
		}

		public Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<Gameplay.Features.MovementFeature.CanMove>();

		public Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public Gameplay.EntitiesCore.Entity AddCanMove(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public Gameplay.Features.MovementFeature.CharacterControllerComponent CharacterControllerC => GetComponent<Gameplay.Features.MovementFeature.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Gameplay.Features.MovementFeature.CharacterControllerComponent() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Gameplay.Features.LifeCycle.CurrentHealth>();

		public Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.CurrentHealth() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddCurrentHealth(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<Gameplay.Features.LifeCycle.MaxHealth>();

		public Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.MaxHealth() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddMaxHealth(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<Gameplay.Features.LifeCycle.IsDead>();

		public Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.IsDead() { Value = new Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddIsDead(Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<Gameplay.Features.LifeCycle.MustDie>();

		public Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public Gameplay.EntitiesCore.Entity AddMustDie(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public Gameplay.EntitiesCore.Entity AddMustSelfRelease(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<Gameplay.Features.LifeCycle.InDeathProcess>();

		public Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.InDeathProcess() { Value = new Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddInDeathProcess(Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.InDeathProcess() {Value = value}); 
		}

		public Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddBodyContactDamage(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Gameplay.Features.Attack.StartAttackRequest>();

		public Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Gameplay.Features.Attack.StartAttackRequest() { Value = new Utilities.Reactive.ReactiveEvent() }); 
		}

		public Gameplay.EntitiesCore.Entity AddStartAttackRequest(Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Gameplay.Features.Attack.StartAttackRequest() {Value = value}); 
		}

		public Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Gameplay.Features.Attack.StartAttackEvent>();

		public Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Gameplay.Features.Attack.StartAttackEvent() { Value = new Utilities.Reactive.ReactiveEvent() }); 
		}

		public Gameplay.EntitiesCore.Entity AddStartAttackEvent(Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Gameplay.Features.Attack.StartAttackEvent() {Value = value}); 
		}

		public Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Gameplay.Features.Attack.CanStartAttack>();

		public Utilities.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public Gameplay.EntitiesCore.Entity AddCanStartAttack(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Gameplay.Features.Attack.EndAttackEvent>();

		public Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Gameplay.Features.Attack.EndAttackEvent() { Value = new Utilities.Reactive.ReactiveEvent() }); 
		}

		public Gameplay.EntitiesCore.Entity AddEndAttackEvent(Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Gameplay.Features.Attack.EndAttackEvent() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackProcessInitialTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value}); 
		}

		public Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Gameplay.Features.Attack.InAttackProcess>();

		public Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new Gameplay.Features.Attack.InAttackProcess() { Value = new Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddInAttackProcess(Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Gameplay.Features.Attack.InAttackProcess() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Gameplay.Features.Attack.AttackDelayTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackDelayTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackDelayTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackDelayTime() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackDelayEndEvent() { Value = new Utilities.Reactive.ReactiveEvent() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value}); 
		}

		public Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Gameplay.Features.Attack.InstantAttackDamage>();

		public Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Gameplay.Features.Attack.InstantAttackDamage() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.InstantAttackDamage() {Value = value}); 
		}

		public Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Gameplay.Features.Attack.ShootPoint() {Value = value}); 
		}

		public Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<Gameplay.Features.Attack.MustCancelAttack>();

		public Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public Gameplay.EntitiesCore.Entity AddMustCancelAttack(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.Attack.MustCancelAttack() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => GetComponent<Gameplay.Features.Attack.AttackCanceledEvent>();

		public Utilities.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackCanceledEvent()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCanceledEvent() { Value = new Utilities.Reactive.ReactiveEvent() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackCanceledEvent(Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCanceledEvent() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value}); 
		}

		public Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = new Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value}); 
		}

		public Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Gameplay.Features.Attack.InAttackCooldown>();

		public Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Gameplay.Features.Attack.InAttackCooldown() { Value = new Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddInAttackCooldown(Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Gameplay.Features.Attack.InAttackCooldown() {Value = value}); 
		}

		public Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public Gameplay.EntitiesCore.Entity AddCanApplyDamage(Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value}); 
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
