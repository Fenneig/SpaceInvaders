using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceInvaders
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Movement _movement;
        private GameSpace _gameSpace;
        private DefenderInput _defenderInput;

        [Inject]
        private void Construct(GameSpace gameSpace) =>
            _gameSpace = gameSpace;
        
        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            _movement = new Movement(rectTransform, _speed, _gameSpace.SpaceWidth);
            
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

        private void OnShoot(InputAction.CallbackContext context)
        {
            Debug.Log("shoot");
        }

        private void OnEnable() => 
            _defenderInput.Enable();

        private void OnDisable() => 
            _defenderInput.Disable();

        private void Update() => 
            _movement.Move();
    }
}
