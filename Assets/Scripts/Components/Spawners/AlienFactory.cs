using SpaceInvaders.Components.Units;
using Zenject;

namespace SpaceInvaders.Components.Spawners
{
    public class AlienFactory : Factory<Alien>
    {
        public AlienFactory(DiContainer diContainer, GameSpace gameSpace) : base(diContainer, gameSpace)
        { }
    }
}