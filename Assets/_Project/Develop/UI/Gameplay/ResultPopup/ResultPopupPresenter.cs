using Gameplay.Infrastructure;
using UI.Core;
using UI.Gameplay;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;

namespace UI.Gameplay
{
    public class ResultPopupPresenter : PopupPresenterBase
    {
        private readonly ResultPopupView _view;
        private readonly GameResultService _gameResultService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly SceneSwitcherService _sceneSwitcherService;

        public ResultPopupPresenter(
            ResultPopupView view, 
            GameResultService gameResultService,
            ICoroutinesPerformer coroutinesPerformer, 
            SceneSwitcherService sceneSwitcherService)
        {
            _view = view;
            _gameResultService = gameResultService;
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetText(_gameResultService.ResultMessage);
            _view.SetButtonTitle(_gameResultService.ButtonText);
            _view.SetOnClick(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(_gameResultService.SceneToSwitch, _gameResultService.InputArgs));
        }
    }
}