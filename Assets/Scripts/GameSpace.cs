using UnityEngine;

namespace SpaceInvaders
{
    public class GameSpace : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public float SpaceWidth => _rectTransform.rect.width;
    }
}