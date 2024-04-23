using SpaceInvaders.Components.Units;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.DI
{
    public class AlienGridInstaller : MonoInstaller
    {
        [SerializeField] private AlienGrid _alienGrid;
        public override void InstallBindings()
        {
            Container.Bind<AlienGrid>().FromInstance(_alienGrid).AsSingle();
        }
    }
}