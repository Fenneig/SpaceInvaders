using SpaceInvaders.Components.Units;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.DI
{
    public class DefenderInstaller : MonoInstaller
    {
        [SerializeField] private Defender _defender;

        public override void InstallBindings()
        {
            Container.Bind<Defender>().FromInstance(_defender).AsSingle();
        }
    }
}