using System.Collections.Generic;
using UnityEngine;

namespace Utilities.SequenceManagment
{
    [CreateAssetMenu(menuName = "Configs/SequenceConfig", fileName = "SequenceConfig")]
    public class SequenceConfig : ScriptableObject
    {
        [field: SerializeField] public int Length { get; private set; } = 5;
        [field: SerializeField] public KeyCode EnterKey { get; private set; } = KeyCode.Return;
        [field: SerializeField] public List<char> NumberCharacters { get; private set; } 
            = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        [field: SerializeField] public List<char> LetterCharacters { get; private set; } 
            = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
