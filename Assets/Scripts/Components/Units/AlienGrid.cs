using SpaceInvaders.Components.Movements;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SpaceInvaders.Components.Units
{
    public class AlienGrid : MonoBehaviour
    {
        [SerializeField] private RectTransform _transform;
        [SerializeField] private float _speed;
        [SerializeField] private float _verticalDistance;
        private GameSpace _gameSpace;
        private Movement _movement;


        [Inject]
        private void Construct(GameSpace gameSpace) =>
            _gameSpace = gameSpace;

        private void Awake()
        {
            var randomDir = Random.Range(0, 2);
            _movement = new Movement(_transform, _speed, _gameSpace.SpaceWidth);
            _movement.Direction = randomDir == 0 ? -1f : 1f;
        }

        private void Update()
        {
            if (_movement.TryMove())
                return;
            
            Vector2 newPosition = new Vector2(_transform.localPosition.x, _transform.localPosition.y - _verticalDistance);
            _transform.localPosition = newPosition;
            _movement.Direction *= -1;
        }
    }
}