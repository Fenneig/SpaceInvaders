using UnityEngine;
using Zenject;

namespace SpaceInvaders.Components
{
    public class ProjectileFactory
    {
        private DiContainer _diContainer;
        private GameSpace _gameSpace;

        public ProjectileFactory(DiContainer diContainer, GameSpace gameSpace)
        {
            _diContainer = diContainer;
            _gameSpace = gameSpace;
        }
        
        public Projectile Get(Projectile prefab, Vector2 position)
        {
            GameObject instance = _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, _gameSpace.transform);
            return instance.GetComponent<Projectile>();
        }
    }
}