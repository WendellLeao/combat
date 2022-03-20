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
            UpdateMovementAnimation();
        }

        private void UpdateMovementAnimation()
        {
            _animator.SetFloat(VelocityHash, _playerMovement.Velocity);

            // Debug.Log(_playerMovement.Velocity);
        }
    }
}