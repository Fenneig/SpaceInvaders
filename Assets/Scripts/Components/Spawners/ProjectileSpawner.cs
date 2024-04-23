using System.Collections.Generic;
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
        private List<Projectile> _projectiles = new List<Projectile>();

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
            projectile.OnProjectileDestroy += RemoveProjectile;
            _projectiles.Add(projectile);

            projectile.Init(shooterSide, projectileColor, _projectileConfig.Speed);

            projectile.Fire(direction);
        }

        public void RemoveAllProjectiles()
        {
            _projectiles.ForEach(projectile => projectile.DestroyGO());
            
            _projectiles = new List<Projectile>();
        }

        private void RemoveProjectile(Projectile projectile)
        {
            _projectiles.Remove(projectile);
            projectile.DestroyGO();
        }
    }
}