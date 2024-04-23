using SpaceInvaders.Components;
using UnityEngine;

namespace SpaceInvaders.Configs
{
    [CreateAssetMenu(fileName = "Projectile config", menuName = "Configs/projectile config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private float _speed;
        [SerializeField] private Color _alienProjectileColor;
        [SerializeField] private Color _defenderProjectileColor;

        public Projectile Prefab => _prefab;

        public float Speed => _speed;

        public Color AlienProjectileColor => _alienProjectileColor;

        public Color DefenderProjectileColor => _defenderProjectileColor;
    }
}