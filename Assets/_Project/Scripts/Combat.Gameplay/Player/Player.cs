using UnityEngine;

namespace Combat.Gameplay.Player
{
    public sealed class Player : Entity
    {
        [Header("Player Components")]
        [SerializeField] private PlayerMovement _playerMovement;
        
        [Header("Animations")]
        [SerializeField] private PlayerAnimationsController _playerAnimationsController;

        public void Initialize(Camera mainCamera)
        {
            _playerMovement.Initialize(mainCamera);
            
            _playerAnimationsController.Initialize(_playerMovement);
        }
        
        public void Dispose()
        {}
        
        public void Tick(float deltaTime)
        {
            _playerMovement.Tick(deltaTime);
            
            _playerAnimationsController.Tick(deltaTime);
        }
    }
}