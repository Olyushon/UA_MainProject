using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Features.SequenceManagment
{
    [CreateAssetMenu(menuName = "Configs/SequenceConfig", fileName = "SequenceConfig")]
    public class SequenceConfig : ScriptableObject
    {
        [field: SerializeField] public List<char> Characters { get; private set; } = new List<char>();
    }
}
