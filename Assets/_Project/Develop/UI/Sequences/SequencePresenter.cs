using System;
using UI.CommonViews;
using UI.Core;
using Utilities.Reactive;

namespace UI.Sequences
{
    public class SequencePresenter : IPresenter
    {
        private readonly string _sequenceTitle;
        private readonly IReadOnlyVariable<string> _sequence;
        private readonly TitleTextView _view;

        private IDisposable _sequenceSubscription;

        public SequencePresenter(
            string sequenceTitle, 
            IReadOnlyVariable<string> sequence, 
            TitleTextView view)
        {
            _sequenceTitle = sequenceTitle;
            _sequence = sequence;
            _view = view;
        }

        public void Initialize()
        {
            _view.SetTitle(_sequenceTitle);

            UpdateText(_sequence.Value);
            _sequenceSubscription = _sequence.Subscribe(OnSequenceChanged);
        }

        public void Dispose()
        {
            _sequenceSubscription?.Dispose();
        }

        private void OnSequenceChanged(string oldValue, string newValue) => UpdateText(newValue);

        private void UpdateText(string value) => _view.SetText(value);

    }
}
