using Gameplay.EntitiesCore;
using Gameplay.EntitiesCore.Systems;
using UnityEngine;
using Utilities;
using Utilities.Reactive;

public class DeathMaskTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
{
    private Buffer<Collider> _contacts;
    private LayerMask _deathMask;
    private ReactiveVariable<bool> _isTouchDeathMask;

    public void OnInitialize(Entity entity)
    {
        _contacts = entity.ContactCollidersBuffer;
        _deathMask = entity.DeathMask;
        _isTouchDeathMask = entity.IsTouchDeathMask;
    }

    public void OnUpdate(float deltaTime)
    {
        for (int i = 0; i < _contacts.Count; i++) {
            if (MatchWithDeathLayer(_contacts.Items[i])) {
                _isTouchDeathMask.Value = true;
                return;
            }
        }

        _isTouchDeathMask.Value = false;
    }

    private bool MatchWithDeathLayer(Collider collider)
    {
        return ((1 << collider.gameObject.layer) & _deathMask) != 0;
    }
}
