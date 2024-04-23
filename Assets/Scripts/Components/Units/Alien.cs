using System;
using SpaceInvaders.Enums;
using SpaceInvaders.Interfaces;
using SpaceInvaders.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceInvaders.Components.Units
{
    public class Alien : MonoBehaviour, IDamageable
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Transform _shootTransform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Image _visual;
        private ProjectileSpawner _projectileSpawner;
        public ConflictSide Side { get; private set; }
        public bool IsDead { get; private set; }
        public RectTransform RectTransform => _rectTransform;
        public float Width => _rectTransform.rect.width;
        public float Height => _rectTransform.rect.height; 
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
            IsDead = true;
            Died?.Invoke();
        }

        public void MoveRight(int spacesAmount)
        {
            float newPosition = _rectTransform.anchoredPosition.x - (Width + Constants.SPACING) * spacesAmount;
            _rectTransform.anchoredPosition = new Vector2(newPosition, 0);
        }
        
        public void Clear()
        {
            Died = null;
            Destroy(gameObject);
        }

        private void Awake() => 
            Side = ConflictSide.Aliens;
    }
}