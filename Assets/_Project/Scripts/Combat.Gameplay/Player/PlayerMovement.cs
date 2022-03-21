using Combat.Gameplay.Inputs;
using System.Collections;
using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(Player))]
    public sealed class PlayerMovement : MonoBehaviour, ICanMove
    {
        [Header("Movement")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _maxSpeed = 7.2f;
        
        [Header("Rotation")]
        [SerializeField] private float _turnSmoothTime = 0.1f;
        
        private PlayerInputsListener _playerInputsListener;
        private Camera _mainCamera;
        private Vector2 _movement;
        private float _turnSmoothVelocity;
        private float _speed;
        
        public float Speed => _speed;
        
        public void Initialize(PlayerInputsListener playerInputsListener, Camera mainCamera)
        {
            _playerInputsListener = playerInputsListener;
            
            _playerInputsListener.OnReadPlayerInputs += HandleReadPlayerInputs;
            
            _mainCamera = mainCamera;

            ResetSpeed();
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

            if (direction.magnitude < 0.1f)
            {
                ResetSpeed();
                
                return;
            }
            
            UpdateRotation(direction);
            
            Vector3 newDirection = GetNewDirection(direction).normalized;
                
            _characterController.Move(newDirection * _speed * deltaTime);
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

        public void SetSpeed(float targetSpeed, float timeMultiplier)
        {
            if (timeMultiplier <= 0f)
            {
                _speed = targetSpeed;

                return;
            }
            
            StartCoroutine(IncreaseSpeedRoutine(targetSpeed, timeMultiplier));
        }

        private IEnumerator IncreaseSpeedRoutine(float targetSpeed, float timeMultiplier)
        {
            if (_speed >= targetSpeed)
            {
                yield break;
            }
            
            yield return new WaitForSeconds(1f * timeMultiplier);

            _speed++;

            StartCoroutine(IncreaseSpeedRoutine(targetSpeed, timeMultiplier));
        }

        private void ResetSpeed()
        {
            _speed = _maxSpeed;
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
        
        public bool PlayerIsMoving()
        {
            if (_movement.x != 0)
            {
                return true;
            }
                    
            if (_movement.y != 0)
            {
                return true;
            }
        
            return false;
        }
    }
}