using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.Components.Spawners
{
    public abstract class Factory<T> where T : Object
    {
        private DiContainer _diContainer;
        private GameSpace _gameSpace;

        public Factory(DiContainer diContainer, GameSpace gameSpace)
        {
            _diContainer = diContainer;
            _gameSpace = gameSpace;
        }

        public T Get(T prefab, Vector2 position, Transform parent = null)
        {
            Transform parentTransform = parent == null ? _gameSpace.transform : parent;
            GameObject instance = _diContainer.InstantiatePrefab(prefab, position, quaternion.identity, parentTransform);
            return instance.GetComponent<T>();
        }
    }
}