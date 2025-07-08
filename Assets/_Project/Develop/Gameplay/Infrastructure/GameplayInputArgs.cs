using Utilities.SceneManagment;
using Utilities.SequenceManagment;

namespace Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(SequenceType sequenceType)
        {
            SequenceType = sequenceType;
        }

        public SequenceType SequenceType { get; }
    }
}