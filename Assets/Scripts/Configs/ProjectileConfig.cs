using SpaceInvaders.Components;
using UnityEngine;

namespace SpaceInvaders.Configs
{
    [CreateAssetMenu(fileName = "Projectile config", menuName = "Configs/projectile config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Color _alienProjectileColor;
        [SerializeField] private Color _defenderProjectileColor;

        public Projectile Prefab => _prefab;

        public Color AlienProjectileColor => _alienProjectileColor;

        public Color DefenderProjectileColor => _defenderProjectileColor;
    }
}