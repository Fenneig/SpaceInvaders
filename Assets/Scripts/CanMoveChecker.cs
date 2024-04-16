using UnityEngine;

namespace SpaceInvaders
{
    public class CanMoveChecker
    {
        private RectTransform _checkTransform;
        private float _gameSpaceWidth;
        private float MaxDistance => _gameSpaceWidth / 2 - _checkTransform.rect.width / 2;

        public CanMoveChecker(RectTransform checkTransform, float gameSpaceWidth)
        {
            _checkTransform = checkTransform;
            _gameSpaceWidth = gameSpaceWidth;
        }

        public bool Check(float newPosition) => 
            newPosition > -MaxDistance && newPosition < MaxDistance;
    }
}