using System;
using SpaceInvaders.Enums;
using SpaceInvaders.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceInvaders.Components.Units
{
    public class Alien : MonoBehaviour, IDamageable
    {
        [SerializeField] private Transform _shootTransform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Image _visual;
        private ProjectileSpawner _projectileSpawner;
        public ConflictSide Side { get; private set; }

        public event Action Died;

        [Inject]
        private void Construct(ProjectileSpawner projectileSpawner) =>
            _projectileSpawner = projectileSpawner;

        public void Shoot() => 
            _projectileSpawner.Spawn(_shootTransform.position, Side);

        public void Damage()
        {
            _visual.enabled = false;
            _collider.enabled = false;
            Died?.Invoke();
        }

        private void Awake() => 
            Side = ConflictSide.Aliens;

        private void Update()
        {
            if (Input.GetKey(KeyCode.E))
                Shoot();
        }
    }
}