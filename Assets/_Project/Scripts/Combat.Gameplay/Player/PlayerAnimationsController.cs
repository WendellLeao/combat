using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsMovingHash = Animator.StringToHash("isMoving");
        
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
            bool playerIsMoving = PlayerIsMoving();
            
            _animator.SetBool(IsMovingHash, playerIsMoving);
        }

        private bool PlayerIsMoving()
        {
            if (_playerMovement.Movement.x != 0)
            {
                return true;
            }
            
            if (_playerMovement.Movement.y != 0)
            {
                return true;
            }

            return false;
        }
    }
}