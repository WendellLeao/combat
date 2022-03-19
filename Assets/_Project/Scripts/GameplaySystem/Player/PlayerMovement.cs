using UnityEngine;

namespace Combat.GameplaySystem.Player
{
    public sealed class PlayerMovement : MonoBehaviour, ICanMove
    {
        [Header("Movement")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 6f;
        
        [Header("Rotation")]
        [SerializeField] private float _turnSmoothTime = 0.1f;
        
        private const string HorizontalInputName = "Horizontal";
        private const string VerticalInputName = "Vertical";
        
        private float _turnSmoothVelocity;
        private Camera _mainCamera;

        public float Speed => _speed;

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Move(float deltaTime)
        {
            float horizontalAxisSpeed = Input.GetAxisRaw(HorizontalInputName);
            float verticalAxisSpeed = Input.GetAxisRaw(VerticalInputName);

            Vector3 direction = new Vector3(horizontalAxisSpeed, 0f, verticalAxisSpeed).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float smoothAngle = GetSmoothAngle(direction);

                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
                
                Vector3 movementDirection = Quaternion.Euler(0f, smoothAngle, 0f) * Vector3.forward;
                
                _characterController.Move(movementDirection.normalized * _speed * deltaTime);
            }
        }

        private float GetSmoothAngle(Vector3 direction)
        {
            float mainCameraAngle = _mainCamera.transform.eulerAngles.y;
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraAngle;

            float currentAngle = transform.eulerAngles.y;
            
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            return smoothAngle;
        }

        public void SetMainCamera(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }
    }
}