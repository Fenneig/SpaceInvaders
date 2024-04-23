using Zenject;

namespace SpaceInvaders.Components.Spawners
{
    public class ProjectileFactory : Factory<Projectile>
    {
        public ProjectileFactory(DiContainer diContainer, GameSpace gameSpace) : base(diContainer, gameSpace)
        { }
    }
}