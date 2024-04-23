using SpaceInvaders.Components.Spawners;
using Zenject;

namespace SpaceInvaders.DI
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProjectileFactory>().FromNew().AsSingle();
            Container.Bind<AlienFactory>().FromNew().AsSingle();
        }
    }
}