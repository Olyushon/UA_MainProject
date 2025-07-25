using Infrastructure.DI;
using Utilities.AssetsManagment;
using Gameplay.Features.SequenceManagment;
using Gameplay.Features.UserInputManagment;

namespace Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateSequenceService);
            container.RegisterAsSingle(CreateUserInputService);
        }

        private static SequenceService CreateSequenceService(DIContainer c)
        {
            ResourcesLoader resourcesLoader = c.Resolve<ResourcesLoader>();

            SequenceMainConfig sequenceMainConfig = resourcesLoader
                .Load<SequenceMainConfig>("Configs/SequenceMainConfig");

            return new SequenceService(sequenceMainConfig, resourcesLoader);
        }

        private static UserInputService CreateUserInputService(DIContainer c)
        {
            return new UserInputService();
        }
    }
}