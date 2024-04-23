using UnityEngine;

namespace SpaceInvaders.Components
{
    public class GameSpace : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        public float SpaceWidth => _rectTransform.rect.width;
    }
}