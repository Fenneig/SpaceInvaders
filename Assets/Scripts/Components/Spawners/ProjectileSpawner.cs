using SpaceInvaders.Components.Spawners;
using SpaceInvaders.Configs;
using SpaceInvaders.Enums;
using UnityEngine;

namespace SpaceInvaders.Components
{
    public class ProjectileSpawner
    {
        private ProjectileFactory _factory;
        private ProjectileConfig _projectileConfig;

        public ProjectileSpawner(ProjectileFactory factory, ProjectileConfig projectileConfig)
        {
            _factory = factory;
            _projectileConfig = projectileConfig;
        }

        public void Spawn(Vector2 position, ConflictSide shooterSide)
        {
            Vector2 direction = shooterSide == ConflictSide.Defenders ? Vector2.up : Vector2.down;
            Color projectileColor = shooterSide == ConflictSide.Defenders
                ? _projectileConfig.DefenderProjectileColor
                : _projectileConfig.AlienProjectileColor;

            Projectile projectile = _factory.Get(_projectileConfig.Prefab, position);

            projectile.Init(shooterSide, projectileColor, _projectileConfig.Speed);

            projectile.Fire(direction);
        }
    }
}