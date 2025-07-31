using Infrastructure;
using Infrastructure.DI;
using Utilities.CoroutinesManagment;
using Utilities.SceneManagment;
using System.Collections;
using UnityEngine;
using Gameplay.Features.GameModeManagment;
using Utilities.DataManagment.DataProviders;
using Meta.Features.Counters;
using Gameplay.Features.InfoManagment;
using Meta.Features.Wallet;
using Gameplay.Features.ResetProgressManagment;
using UI.Wallet;
using UI.Counters;
using UI.CommonViews;
using UI.Core;

namespace Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private readonly string _menuMessage = "Keycodes: I - counters info; W - wallet info; R - reset counters; S - save;"; // Temp
        private DIContainer _container;
        private GameModeSelector _gameModeSelector;
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;
        private InfoService _infoService;
        private WalletService _walletService;
        private CountersDataService _countersDataService;
        private ResetCountersService _resetCountersService;

        // [SerializeField] private IconTextView _currencyView;
        // [SerializeField] private TitleValueView _counterView;
        [SerializeField] private Transform _viewsParent;
        private IconTextView _currencyView;
        private TitleValueView _counterView;
        private ViewsFactory _viewsFactory;
        private ProjectPresentersFactory _presentersFactory;
        private CurrencyPresenter _currencyPresenter;
        private CounterPresenter _counterPresenter;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            _playerDataProvider = _container.Resolve<PlayerDataProvider>();

            _presentersFactory = _container.Resolve<ProjectPresentersFactory>();
            _viewsFactory = _container.Resolve<ViewsFactory>();
            
            yield break;
        }

        public override void Run()
        {
            Debug.Log("Main menu scene");
            Debug.Log(_menuMessage);

            _gameModeSelector = _container.Resolve<GameModeSelector>();
            _gameModeSelector.Start();

            _infoService = _container.Resolve<InfoService>();
            _walletService = _container.Resolve<WalletService>();
            _countersDataService = _container.Resolve<CountersDataService>();

            _resetCountersService = _container.Resolve<ResetCountersService>();
        }

        private void Update()
        {
            _gameModeSelector?.Update(Time.deltaTime);

            _infoService?.Update(Time.deltaTime);

            _resetCountersService?.Update(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                Debug.Log("Save");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                // _currencyPresenter = _presentersFactory.CreateCurrencyPresenter(
                //     _walletService.GetCurrency(CurrencyType.Gold),
                //     CurrencyType.Gold,
                //     _currencyView);

                // _currencyPresenter.Enable();

                _counterPresenter?.Disable();

                if (_counterView != null)
                    _viewsFactory.Release(_counterView);

                _counterView = _viewsFactory.Create<TitleValueView>(ViewIDs.CounterView, _viewsParent);

                _counterPresenter = _presentersFactory.CreateCounterPresenter(
                    _countersDataService.GetCount(CounterType.Win),
                    CounterType.Win,
                    _counterView);

                _counterPresenter.Enable();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _counterPresenter?.Disable();
                
                if (_counterView != null)
                    _viewsFactory.Release(_counterView);

                _counterView = _viewsFactory.Create<TitleValueView>(ViewIDs.CounterView, _viewsParent);

                _counterPresenter = _presentersFactory.CreateCounterPresenter(
                    _countersDataService.GetCount(CounterType.Lose),
                    CounterType.Lose,
                    _counterView);

                _counterPresenter.Enable();
            }
        }
    }
}