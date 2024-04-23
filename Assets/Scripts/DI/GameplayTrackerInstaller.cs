using SpaceInvaders.Utils;
using Zenject;

namespace SpaceInvaders.DI
{
    public class GameplayTrackerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplayTracker>().FromNew().AsSingle();
        }
    }
}