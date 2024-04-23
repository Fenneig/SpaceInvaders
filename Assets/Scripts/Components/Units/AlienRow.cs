using System;
using System.Collections.Generic;
using SpaceInvaders.Components.Spawners;
using SpaceInvaders.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceInvaders.Components.Units
{
    public class AlienRow : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        private List<Alien> _availableAliens;
        private Vector2 _alienSize;
        public RectTransform RectTransform => _rectTransform;
        public float Width { get; private set; }
        public float Height { get; private set; }
        public bool IsRowCleared { get; private set; }
        public delegate void RowSizeChanged(bool fromLeftSide);
        public event RowSizeChanged OnRowSizeChanged;
        public event Action OnRowCleared;

        public void Initialize(Alien alienPrefab, int aliensInRow, AlienFactory alienFactory)
        {
            _availableAliens = new List<Alien>();
            _alienSize = new Vector2(alienPrefab.Width, alienPrefab.Height);
            for (int i = 0; i < aliensInRow; i++)
            {
                float newPositionX = (_alienSize.x + Constants.SPACING) * i + Constants.SPACING / 2;
                Vector2 position = new Vector2(newPositionX, 0);
                Alien alien = alienFactory.Get(alienPrefab, position, transform);
                alien.RectTransform.localPosition = position;
                _availableAliens.Add(alien);
                alien.Died += OnAlienDied;
            }

            Width = (_alienSize.x + Constants.SPACING) * aliensInRow;
            Height = _alienSize.y + Constants.SPACING;
            _rectTransform.sizeDelta = new Vector2(Width, Height);
        }

        public void Clear()
        {
            _availableAliens.ForEach(alien => alien.Clear());
            OnRowSizeChanged = null;
            OnRowCleared = null;
            Destroy(gameObject);
        }

        public void Move(float moveAmount)
        {
            Vector2 newPosition = new Vector2(_rectTransform.anchoredPosition.x + moveAmount, _rectTransform.anchoredPosition.y);
            _rectTransform.anchoredPosition = newPosition;
        }

        public void Shoot()
        {
            bool isShot = false;
            while (isShot == false)
            {
                int randomAlien = Random.Range(0, _availableAliens.Count);
                if (_availableAliens[randomAlien].TryShoot())
                    isShot = true;
            }
        }

        private void OnAlienDied()
        {
            if (_availableAliens.Count <= 1)
            {
                IsRowCleared = true;
                OnRowCleared?.Invoke();
                Clear();
                return;
            }
            
            ClearLeftSide();
            ClearRightSide();
        }

        private void ClearLeftSide()
        {
            int diedAmount = 0;

            for (int i = 0; i < _availableAliens.Count; i++)
            {
                if (_availableAliens[i].IsDead)
                {
                    diedAmount++;
                    _availableAliens[i].Clear();
                }
                else
                {
                    break;
                }
            }

            if (diedAmount > 0)
            {
                float newPositionX =
                    _rectTransform.localPosition.x + (_alienSize.x + Constants.SPACING) * diedAmount / 2;
                _rectTransform.localPosition = new Vector2(newPositionX, _rectTransform.localPosition.y);
                _availableAliens.RemoveRange(0, diedAmount);
                _availableAliens.ForEach(alien => alien.MoveRight(diedAmount));
                Width = (_alienSize.x + Constants.SPACING) * _availableAliens.Count;
                _rectTransform.sizeDelta = new Vector2(Width, Height);
                OnRowSizeChanged?.Invoke(true);
            }
        }

        private void ClearRightSide()
        {
            int diedAmount = 0;

            for (int i = _availableAliens.Count - 1; i > 0; i--)
            {
                if (_availableAliens[i].IsDead)
                {
                    diedAmount++;
                    _availableAliens[i].Clear();
                }
                else
                {
                    break;
                }
            }

            if (diedAmount > 0)
            {
                float newPositionX =
                    _rectTransform.localPosition.x - (_alienSize.x + Constants.SPACING) * diedAmount / 2;
                _rectTransform.localPosition = new Vector2(newPositionX, _rectTransform.localPosition.y);
                _availableAliens.RemoveRange(_availableAliens.Count - diedAmount, diedAmount);
                Width = (_alienSize.x + Constants.SPACING) * _availableAliens.Count;
                _rectTransform.sizeDelta = new Vector2(Width, Height);
                OnRowSizeChanged?.Invoke(false);
            }
        }
    }
}