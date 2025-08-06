using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;
using Infrastructure.DI;

namespace UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateGameplayScreen(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(
                view, 
                _container.Resolve<SequenceService>(),
                _container.Resolve<UserInputService>());
        }
    }
}
