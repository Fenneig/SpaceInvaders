using SpaceInvaders.Components;
using SpaceInvaders.Configs;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.DI
{
    public class ProjectileSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private ProjectileConfig _projectileConfig;

        public override void InstallBindings()
        {
            Container.Bind<ProjectileConfig>().FromInstance(_projectileConfig).AsSingle();

            Container.Bind<ProjectileSpawner>().AsSingle();
        }
    }
}