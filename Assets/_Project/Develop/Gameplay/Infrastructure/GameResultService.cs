using Utilities.SceneManagment;

namespace Gameplay.Infrastructure
{
    public class GameResultService
    {
        private readonly string _winMessage = "You win!";
        private readonly string _winButtonText = "Play again!";
        private readonly string _winSceneToSwitch = Scenes.MainMenu;

        private readonly string _loseMessage = "Wrong! Try again.";
        private readonly string _loseButtonText = "Try again!";
        private readonly string _loseSceneToSwitch = Scenes.Gameplay;

        private string _resultMessage;
        private string _buttonText;
        private string _sceneToSwitch;
        private GameplayInputArgs _inputArgs;

        public GameResultService() {}

        public string ResultMessage => _resultMessage;

        public string ButtonText => _buttonText;

        public string SceneToSwitch => _sceneToSwitch;

        public GameplayInputArgs InputArgs => _inputArgs;

        public void SetWinResult()
        {
            _resultMessage = _winMessage;
            _buttonText = _winButtonText;
            _sceneToSwitch = _winSceneToSwitch;
        }

        public void SetLoseResult(GameplayInputArgs inputArgs)
        {
            _resultMessage = _loseMessage;
            _buttonText = _loseButtonText;
            _sceneToSwitch = _loseSceneToSwitch;
            _inputArgs = inputArgs;
        }
    }
}
