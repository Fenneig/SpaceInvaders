using SpaceInvaders.Components;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.DI
{
    public class GameSpaceInstaller : MonoInstaller
    {
        [SerializeField] private GameSpace _gameSpace;

        public override void InstallBindings()
        {
            Container.Bind<GameSpace>().FromInstance(_gameSpace).AsSingle();
        }
    }
}