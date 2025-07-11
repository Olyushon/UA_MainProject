using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Features.SequenceManagment
{
    public class SequenceService
    {
        private readonly SequenceConfig _sequenceConfig;

        public SequenceService(SequenceConfig sequenceConfig)
        {
            _sequenceConfig = sequenceConfig;
        }

        public KeyCode GetEnterKey()
        {
            return _sequenceConfig.EnterKey;
        }

        public string GetSequence(SequenceType sequenceType)
        {
            switch (sequenceType)
            {
                case SequenceType.Numbers:
                    return GetNumbersSequence();
                case SequenceType.Letters:
                    return GetLettersSequence();
                default:
                    Debug.LogError("Invalid sequence type");
                    return null;
            }
        }

        private string GetNumbersSequence()
        {
            string sequence = "";

            for (int i = 0; i < _sequenceConfig.Length; i++)
            {
                sequence += _sequenceConfig.NumberCharacters[Random.Range(0, _sequenceConfig.NumberCharacters.Count)];
            }

            return sequence;
        }

        private string GetLettersSequence()
        {
            string sequence = "";

            for (int i = 0; i < _sequenceConfig.Length; i++)
            {
                sequence += _sequenceConfig.LetterCharacters[Random.Range(0, _sequenceConfig.LetterCharacters.Count)];
            }
            
            return sequence;
        }
    }
}
