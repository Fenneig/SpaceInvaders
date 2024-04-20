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
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        private ConflictSide _side;
        private const float SPEED_MULTIPLIER = 100f;

        public void Init(ConflictSide side, Color projectileColor)
        {
            _side = side;
            _projectileImage.color = projectileColor;
        }

        public void Fire(Vector2 direction) =>
            _rigidbody.AddForce(direction * _speed * SPEED_MULTIPLIER, ForceMode2D.Impulse);

        private void OnValidate() => 
            _rigidbody ??= GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable collision) == false)
            {
                Destroy(gameObject);
                return;
            }

            if (collision.Side == _side)
                return;
            
            collision.Damage();
            Destroy(gameObject);
        }
    }
}

