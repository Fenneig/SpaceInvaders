using SpaceInvaders.Enums;

namespace SpaceInvaders.Interfaces
{
    public interface IDamageable
    {
        public ConflictSide Side { get; }
        public void Damage();
    }
}