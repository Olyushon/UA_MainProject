using System.Collections.Generic;
using Meta.Features.Counters;
using UI.CommonViews;
using UI.Core;

namespace UI.Counters
{
    public class CountersPresenter : IPresenter
    {
        private readonly CountersDataService _countersDataService;
        private readonly TitleValueListView _countersView;

        private readonly ProjectPresentersFactory _presentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly List<CounterPresenter> _counterPresenters = new();

        public CountersPresenter(
            CountersDataService countersDataService,
            TitleValueListView countersView,
            ProjectPresentersFactory presentersFactory,
            ViewsFactory viewsFactory)
        {
            _countersDataService = countersDataService;
            _countersView = countersView;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
        }

        public void Initialize()
        {
            foreach (CounterType counterType in _countersDataService.AvailableCounters)
            {
                TitleValueView counterView = _viewsFactory.Create<TitleValueView>(ViewIDs.CounterView);

                _countersView.Add(counterView);

                CounterPresenter counterPresenter = _presentersFactory.CreateCounterPresenter(
                    _countersDataService.GetCount(counterType),
                    counterType,
                    counterView);

                counterPresenter.Initialize();
                _counterPresenters.Add(counterPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CounterPresenter counterPresenter in _counterPresenters)
            {
                _countersView.Remove(counterPresenter.View);
                _viewsFactory.Release(counterPresenter.View);
                counterPresenter.Dispose();
            }

            _counterPresenters.Clear();
        }
    }
}
