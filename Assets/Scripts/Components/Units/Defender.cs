using System;
using SpaceInvaders.Components.Movements;
using SpaceInvaders.Enums;
using SpaceInvaders.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceInvaders.Components.Units
{
    public class Defender : MonoBehaviour, IDamageable
    {
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private float _speed;

        private Movement _movement;
        private GameSpace _gameSpace;
        private DefenderInput _defenderInput;
        private ProjectileSpawner _projectileSpawner;
        public ConflictSide Side { get; private set; }

        public event Action Died;

        [Inject]
        private void Construct(GameSpace gameSpace, ProjectileSpawner projectileSpawner)
        {
            _gameSpace = gameSpace;
            _projectileSpawner = projectileSpawner;
        }
        
        public void Damage() => 
            Died?.Invoke();

        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            _movement = new Movement(rectTransform, _speed, _gameSpace.SpaceWidth);
            Side = ConflictSide.Defenders;
            
            SetupInput();
        }

        private void SetupInput()
        {
            _defenderInput = new DefenderInput();
            _defenderInput.Standart.Movement.performed += OnMovement;
            _defenderInput.Standart.Movement.canceled += OnMovement;
            _defenderInput.Standart.Shoot.started += OnShoot;
        }

        private void OnMovement(InputAction.CallbackContext context) => 
            _movement.Direction = context.ReadValue<float>();

        private void OnShoot(InputAction.CallbackContext context) => 
            _projectileSpawner.Spawn(_shootPosition.position, Side);

        private void OnEnable() => 
            _defenderInput.Enable();

        private void OnDisable() => 
            _defenderInput.Disable();

        private void Update() => 
            _movement.Move();
    }
}
