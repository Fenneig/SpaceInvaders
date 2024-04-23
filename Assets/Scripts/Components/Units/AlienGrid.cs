using System;
using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Components.Movements;
using SpaceInvaders.Components.Spawners;
using SpaceInvaders.Configs;
using SpaceInvaders.Utils;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SpaceInvaders.Components.Units
{
    public class AlienGrid : MonoBehaviour
    {
        [SerializeField] private AlienRow _alienRowPrefab;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private float _speed;
        [SerializeField] private float _verticalDistance;
        [SerializeField] private RectTransform _startTransform;
        private List<AlienRow> _alienRows;
        private GameSpace _gameSpace;
        private Movement _movement;
        private AliensPattern _pattern;
        private AlienFactory _alienFactory;
        private Timer _shootTimer;
        private Vector2 _anchoredMinMax = new(.5f, 1f);

        private const double MOVE_TOLERANCE = 0.01f;

        public event Action StageComplete;

        [Inject]
        private void Construct(GameSpace gameSpace, AliensPattern pattern, AlienFactory alienFactory)
        {
            _gameSpace = gameSpace;
            _pattern = pattern;
            _alienFactory = alienFactory;
        }

        public void InitializeStage(int stageNumber)
        {
            _shootTimer.Value = 1f / _pattern.Stages[stageNumber].AttacksPerSecond;
            _shootTimer.Reset();

            InitializeMovement(stageNumber);
            InitializeAlienRows(stageNumber);
        }

        private void Awake() => 
            _shootTimer = new Timer();

        private void InitializeMovement(int stageNumber)
        {
            _transform.position = _startTransform.position;
            
            var randomDir = Random.Range(0, 2);
            _movement = new Movement(_transform, _speed, _gameSpace.SpaceWidth)
            {
                Direction = randomDir == 0 ? -1f : 1f,
                Speed = _pattern.Stages[stageNumber].MovementSpeed
            };
        }

        private void InitializeAlienRows(int stageNumber)
        {
            _alienRows?.ForEach(alienRow => alienRow.Clear());

            _alienRows = new List<AlienRow>();

            for (int i = 0; i < _pattern.Stages[stageNumber].AlienRows.Count; i++)
            {
                Alien alienType = _pattern.Stages[stageNumber].AlienRows[i];
                int aliensInRow = _pattern.Stages[stageNumber].AliensInRow;
                float newPositionY = -(alienType.Height + Constants.SPACING) * i;
                Vector2 rowPosition = new Vector2(0, newPositionY);
                AlienRow newRow = Instantiate(_alienRowPrefab, rowPosition, Quaternion.identity, transform);
                newRow.RectTransform.anchorMin = _anchoredMinMax;
                newRow.RectTransform.anchorMax = _anchoredMinMax;
                newRow.RectTransform.localPosition = rowPosition;
                newRow.Initialize(alienType, aliensInRow, _alienFactory);
                newRow.OnRowSizeChanged += OnRowSizeChanged;
                newRow.OnRowCleared += ClearRows;
                _alienRows.Add(newRow);
            }
            
            UpdateGridSize();
        }

        private void ClearRows()
        {
            _alienRows.RemoveAll(row => row.IsRowCleared);
            
            if (_alienRows.Count == 0)
                StageComplete?.Invoke();
            else
                UpdateGridSize();
        }


        private void OnRowSizeChanged(bool rowChangedFromLeftSide)
        {
            float prevWidth = _transform.sizeDelta.x;
            UpdateGridSize();
            float width = _transform.sizeDelta.x;

            if (prevWidth == 0) 
                prevWidth = width;

            if (Math.Abs(prevWidth - width) < MOVE_TOLERANCE)
                return;
            
            float moveAmount = (prevWidth - width) / 2;
            
            Vector2 newTransformPosition;
            
            if (rowChangedFromLeftSide)
            {
                newTransformPosition = new Vector2(_transform.anchoredPosition.x + moveAmount, _transform.anchoredPosition.y);
                _alienRows.ForEach(row => row.Move(-moveAmount));
            }
            else
            {
                newTransformPosition = new Vector2(_transform.anchoredPosition.x - moveAmount, _transform.anchoredPosition.y);
                _alienRows.ForEach(row => row.Move(moveAmount));
            }
            
            _transform.anchoredPosition = newTransformPosition;
        }

        private void UpdateGridSize()
        {
            float width = _alienRows.Select(alienRow => alienRow.Width).Prepend(0).Max();
            float height = _alienRows[0].Height * _alienRows.Count;

            _transform.sizeDelta = new Vector2(width, height);
        }

        private void Update()
        {
            if (_shootTimer.IsReady)
            {
                Shoot();
                _shootTimer.Reset();
            }
            
            if (_movement.TryMove())
                return;
            
            Vector2 newPosition = new Vector2(_transform.localPosition.x, _transform.localPosition.y - _verticalDistance);
            _transform.localPosition = newPosition;
            _movement.Direction *= -1;
        }

        private void Shoot()
        {
            if (_alienRows.Count <= 0) 
                return;
            
            int randomRow = Random.Range(0, _alienRows.Count);
            _alienRows[randomRow].Shoot();
        }
    }
}