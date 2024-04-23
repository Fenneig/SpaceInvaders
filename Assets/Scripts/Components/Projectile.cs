using System;
using SpaceInvaders.Enums;
using SpaceInvaders.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvaders.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Image _projectileImage;
        [SerializeField] private Rigidbody2D _rigidbody;
        private ConflictSide _side;
        private float _speed;
        private const float SPEED_MULTIPLIER = 100f;
        public event Action<Projectile> OnProjectileDestroy;

        public void Init(ConflictSide side, Color projectileColor, float speed)
        {
            _side = side;
            _speed = speed;
            _projectileImage.color = projectileColor;
        }

        public void Fire(Vector2 direction) =>
            _rigidbody.AddForce(direction * _speed * SPEED_MULTIPLIER, ForceMode2D.Impulse);

        private void OnValidate() => 
            _rigidbody ??= GetComponent<Rigidbody2D>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable collision) == false)
            {
                OnProjectileDestroy?.Invoke(this);
                return;
            }

            if (collision.Side == _side)
                return;
            
            collision.Damage();
            OnProjectileDestroy?.Invoke(this);
        }

        public void DestroyGO() => 
            Destroy(gameObject);
    }
}

