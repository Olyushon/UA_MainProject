using Gameplay.Features.GameModeManagment;
using UI.CommonViews;
using UI.Core;

namespace UI.MainMenu
{
    public class SelectModeTextPresenter : IPresenter
    {
        private readonly TextView _textView;

        private readonly GameModeSelector _gameModeSelector;

        public SelectModeTextPresenter(TextView textView, GameModeSelector gameModeSelector)
        {
            _textView = textView;
            _gameModeSelector = gameModeSelector;
        }

        public void Initialize()
        {
            _textView.SetText(_gameModeSelector.StartMessage);
        }

        public void Dispose()
        {
            
        }
    }
}

