using UnityEngine;

namespace Gameplay.Features.SequenceManagment
{
    [CreateAssetMenu(menuName = "Configs/SequenceMainConfig", fileName = "SequenceMainConfig")]
    public class SequenceMainConfig : ScriptableObject
    {
        [field: SerializeField] public int Length { get; private set; } = 5;
        [field: SerializeField] public KeyCode EnterKey { get; private set; } = KeyCode.Return;
    }
}

