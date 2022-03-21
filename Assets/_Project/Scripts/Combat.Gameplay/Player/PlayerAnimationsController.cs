using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsMovingHash = Animator.StringToHash("isMoving");
        private static readonly int VelocityHash = Animator.StringToHash("Velocity");
        
        private PlayerMovement _playerMovement;

        public void Initialize(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public void Tick(float deltaTime)
        {
            UpdateMovementAnimation();
        }

        private void UpdateMovementAnimation()
        {
            bool playerIsMoving = _playerMovement.PlayerIsMoving();
            
            _animator.SetBool(IsMovingHash, playerIsMoving);

            float speedRatio = _playerMovement.Speed / 20f;
            
            _animator.SetFloat(VelocityHash, speedRatio);

            Debug.Log("Speed Ratio: " + speedRatio);
        }
    }
}