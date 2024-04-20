using UnityEngine;

namespace SpaceInvaders.Components.Movements
{
    public class Movement
    {
        private RectTransform _transformToMove;
        private float _speed;
        private const float SPEED_MULTIPLIER = 100f;
        
        private CanMoveChecker _moveChecker;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float Direction { get; set; }

        public Movement(RectTransform transformToMove, float speed, float gameSpaceWidth)
        {
            _transformToMove = transformToMove;
            _speed = speed;
            _moveChecker = new CanMoveChecker(transformToMove, gameSpaceWidth);
        }

        public bool TryMove()
        {
            Vector3 newPosition = new Vector3(_transformToMove.localPosition.x + _speed * SPEED_MULTIPLIER * Direction * Time.deltaTime, _transformToMove.localPosition.y);
            
            if (_moveChecker.Check(newPosition.x))
            {
                _transformToMove.localPosition = newPosition;
                return true;
            }

            return false;
        }
    }
}