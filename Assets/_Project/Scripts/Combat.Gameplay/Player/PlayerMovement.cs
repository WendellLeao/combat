using Combat.Gameplay.Inputs;
using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(Player))]
    public sealed class PlayerMovement : MonoBehaviour, ICanMove
    {
        [Header("Movement")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 6f;
        [SerializeField] private float _acceleration = 0.1f;
        [SerializeField] private float _deceleration = 0.5f;
        
        [Header("Rotation")]
        [SerializeField] private float _turnSmoothTime = 0.1f;
        
        private PlayerInputsListener _playerInputsListener;
        private Camera _mainCamera;
        private Vector2 _movement;
        private float _turnSmoothVelocity;
        private float _velocity;

        public float Speed => _speed;
        public float Velocity => _velocity;

        public void Initialize(PlayerInputsListener playerInputsListener, Camera mainCamera)
        {
            _playerInputsListener = playerInputsListener;
            
            _playerInputsListener.OnReadPlayerInputs += HandleReadPlayerInputs;
            
            _mainCamera = mainCamera;
        }

        public void Dispose()
        {
            _playerInputsListener.OnReadPlayerInputs -= HandleReadPlayerInputs;
        }
        
        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Move(float deltaTime)
        {
            Vector3 direction = new Vector3(_movement.x, 0f, _movement.y);

            if (direction.magnitude >= 0.1f)
            {
                UpdateRotation(direction);
            
                Vector3 newDirection = GetNewDirection(direction).normalized;
                
                _characterController.Move(newDirection * _speed * deltaTime);
            
                IncreaseVelocity(deltaTime);
            
                return;
            }
            
            DecreaseVelocity(deltaTime);
        }

        private void HandleReadPlayerInputs(PlayerInputsData playerInputsData)
        {
            _movement = playerInputsData.PlayerMovement;
        }

        private void UpdateRotation(Vector3 direction)
        {
            float smoothAngle = GetSmoothAngle(direction);
                
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }
        
        private void IncreaseVelocity(float deltaTime)
        {
            if (_velocity >= 1f)
            {
                return;
            }
            
            _velocity += deltaTime * _acceleration;
        }
        
        private void DecreaseVelocity(float deltaTime)
        {
            if (_velocity <= 0f)
            {
                return;
            }
            
            _velocity -= deltaTime * _deceleration;
        }

        private Vector3 GetNewDirection(Vector3 direction)
        {
            Transform mainCameraTransform = _mainCamera.transform;
                
            Vector3 horizontalDirection = mainCameraTransform.forward * direction.z;
            Vector3 depthDirection = mainCameraTransform.right * direction.x;
                
            direction = horizontalDirection + depthDirection;
            direction.y = 0f;

            return direction;
        }
        
        private float GetSmoothAngle(Vector3 direction)
        {
            float mainCameraAngle = _mainCamera.transform.eulerAngles.y;
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraAngle;

            float currentAngle = transform.eulerAngles.y;
            
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            return smoothAngle;
        }
    }
}