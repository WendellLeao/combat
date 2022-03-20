using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int VelocityHash = Animator.StringToHash("Velocity");
        
        private PlayerMovement _playerMovement;

        public void Initialize(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public void Tick(float deltaTime)
        {
            UpdateMovementAnimation(deltaTime);
        }

        private void UpdateMovementAnimation(float deltaTime)
        {
            Vector3 movement = new Vector3(_playerMovement.Movement.x, 0f, _playerMovement.Movement.y);
            
            float velocityX = Vector3.Dot(movement.normalized, transform.right);
            float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
            
            _animator.SetFloat(VelocityHash, velocityX);
            _animator.SetFloat(VelocityHash, velocityZ);
        }
    }
}