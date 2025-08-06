using System.Collections.Generic;
using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;
using UI.Core;
using UI.Sequences;


namespace UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly string _generatedStringTitle = "Generated string:";
        private readonly string _userInputStringTitle = "User input string:";

        private readonly GameplayScreenView _screen;

        private readonly SequenceService _sequenceService;
        private readonly UserInputService _userInputService;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screen, 
            SequenceService sequenceService,
            UserInputService userInputService)
        {
            _screen = screen;
            _sequenceService = sequenceService;
            _userInputService = userInputService;
        }

        public void Initialize()
        {
            CreateGeneratedStringPresenter();
            CreateUserInputStringPresenter();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateGeneratedStringPresenter()
        {
            SequencePresenter generatedStringPresenter = new SequencePresenter(
                _generatedStringTitle, 
                _sequenceService.Sequence, 
                _screen.GeneratedStringView);

            _childPresenters.Add(generatedStringPresenter);
        }

        private void CreateUserInputStringPresenter()
        {
            SequencePresenter userInputStringPresenter = new SequencePresenter(
                _userInputStringTitle, 
                _userInputService.CurrentSequence, 
                _screen.UserInputStringView);

            _childPresenters.Add(userInputStringPresenter);
        }
    }
}
