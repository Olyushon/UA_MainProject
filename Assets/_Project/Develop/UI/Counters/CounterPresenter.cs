using System;
using Meta.Features.Counters;
using UI.CommonViews;
using UI.Core;
using Utilities.Reactive;

namespace UI.Counters
{
    public class CounterPresenter : IPresenter
    {
        //Бизнес логика
        private readonly IReadOnlyVariable<int> _counter;
        private readonly CounterType _counterType;

        //Визуал
        private readonly TitleValueView _view;

        private IDisposable _counterSubscription;

        public CounterPresenter(
            IReadOnlyVariable<int> counter, 
            CounterType counterType, 
            TitleValueView view)
        {
            _counter = counter;
            _counterType = counterType;
            _view = view;
        }

        public TitleValueView View => _view;

        public void Initialize() {
            UpdateValue(_counter.Value);
            _view.SetTitle(_counterType.ToString());

            _counterSubscription = _counter.Subscribe(OnCounterChanged);
        }

        public void Dispose() {     
            _counterSubscription?.Dispose();
        }

        private void OnCounterChanged(int oldValue, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetValue(value.ToString());
    }
}
