using UnityEngine;
using Utilities.AssetsManagment;
using Utilities.Reactive;
using Random = UnityEngine.Random;

namespace Gameplay.Features.SequenceManagment
{
    public class SequenceService
    {
        private readonly SequenceMainConfig _sequenceMainConfig;
        private readonly ResourcesLoader _resourcesLoader;

        private ReactiveVariable<string> _sequence = new ReactiveVariable<string>("");

        public SequenceService(SequenceMainConfig sequenceMainConfig, ResourcesLoader resourcesLoader)
        {
            _sequenceMainConfig = sequenceMainConfig;
            _resourcesLoader = resourcesLoader;
        }

        public IReadOnlyVariable<string> Sequence => _sequence;

        public KeyCode GetEnterKey() => _sequenceMainConfig.EnterKey;

        public IReadOnlyVariable<string> GenerateSequenceByType(SequenceType sequenceType)
        {
            SequenceConfig sequenceConfig;

            switch (sequenceType)
            {
                case SequenceType.Numbers:
                    sequenceConfig = _resourcesLoader.Load<SequenceConfig>("Configs/NumbersSequenceConfig");
                    _sequence.Value = GenerateSequence(sequenceConfig);
                    break;
                case SequenceType.Letters:
                    sequenceConfig = _resourcesLoader.Load<SequenceConfig>("Configs/LettersSequenceConfig");
                    _sequence.Value = GenerateSequence(sequenceConfig);
                    break;
                default:
                    Debug.LogError("Invalid sequence type");
                    break;
            }

            return _sequence;
        }

        private string GenerateSequence(SequenceConfig sequenceConfig)
        {
            string sequence = "";

            for (int i = 0; i < _sequenceMainConfig.Length; i++)
            {
                sequence += sequenceConfig.Characters[Random.Range(0, sequenceConfig.Characters.Count)];
            }

            return sequence;
        }

        public void ResetSequence() {
            _sequence.Value = "";
        }
    }
}
