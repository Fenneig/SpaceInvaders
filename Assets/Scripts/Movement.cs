using UnityEngine;

namespace SpaceInvaders
{
    public class Movement
    {
        private RectTransform _transform;
        private float _speed;
        private float _direction;
        private const float SPEED_MULTIPLIER = 100f;
        
        private CanMoveChecker _moveChecker;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float Direction
        {
            get => _direction;
            set => _direction = value;
        }

        public Movement(RectTransform transform, float speed, float gameSpaceWidth)
        {
            _transform = transform;
            _speed = speed;
            _moveChecker = new CanMoveChecker(transform, gameSpaceWidth);
        }

        public void Move()
        {
            Vector3 newPosition = new Vector3(_transform.localPosition.x + _speed * SPEED_MULTIPLIER * _direction * Time.deltaTime, _transform.localPosition.y);
            
            if (_moveChecker.Check(newPosition.x))
                _transform.localPosition = newPosition;
        }
    }
}