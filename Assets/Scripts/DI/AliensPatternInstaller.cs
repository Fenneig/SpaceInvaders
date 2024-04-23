using SpaceInvaders.Configs;
using UnityEngine;
using Zenject;

namespace SpaceInvaders.DI
{
    public class AliensPatternInstaller : MonoInstaller
    {
        [SerializeField] private AliensPattern _pattern;

        public override void InstallBindings()
        {
            Container.Bind<AliensPattern>().FromInstance(_pattern).AsSingle();
        }
    }
}