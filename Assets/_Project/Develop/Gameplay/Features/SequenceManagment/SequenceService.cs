using UnityEngine;
using Utilities.AssetsManagment;
using Random = UnityEngine.Random;

namespace Gameplay.Features.SequenceManagment
{
    public class SequenceService
    {
        private readonly SequenceMainConfig _sequenceMainConfig;
        private readonly ResourcesLoader _resourcesLoader;

        public SequenceService(SequenceMainConfig sequenceMainConfig, ResourcesLoader resourcesLoader)
        {
            _sequenceMainConfig = sequenceMainConfig;
            _resourcesLoader = resourcesLoader;
        }

        public KeyCode GetEnterKey()
        {
            return _sequenceMainConfig.EnterKey;
        }

        public string GetSequence(SequenceType sequenceType)
        {
            SequenceConfig sequenceConfig;

            switch (sequenceType)
            {
                case SequenceType.Numbers:
                    sequenceConfig = _resourcesLoader.Load<SequenceConfig>("Configs/NumbersSequenceConfig");
                    return GetSequence(sequenceConfig);
                case SequenceType.Letters:
                    sequenceConfig = _resourcesLoader.Load<SequenceConfig>("Configs/LettersSequenceConfig");
                    return GetSequence(sequenceConfig);
                default:
                    Debug.LogError("Invalid sequence type");
                    return null;
            }
        }

        public string GetSequence(SequenceConfig sequenceConfig)
        {
            string sequence = "";

            for (int i = 0; i < _sequenceMainConfig.Length; i++)
            {
                sequence += sequenceConfig.Characters[Random.Range(0, sequenceConfig.Characters.Count)];
            }

            return sequence;
        }
    }
}
