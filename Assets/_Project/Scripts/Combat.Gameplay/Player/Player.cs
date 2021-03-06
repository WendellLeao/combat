using UnityEngine;

namespace Combat.Gameplay.Player
{
    public sealed class Player : Entity
    {
        [SerializeField] private PlayerInputsListener _playerInputsListener;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerSprint _playerSprint;
        [SerializeField] private PlayerView _playerView;

        public void Initialize(Camera mainCamera)
        {
            _playerInputsListener.Initialize();
                
            _playerMovement.Initialize(_playerInputsListener, mainCamera);
            
            _playerSprint.Initialize(_playerInputsListener);

            _playerView.Initialize(_playerMovement);
        }

        public void Dispose()
        {
            _playerInputsListener.Dispose();
            
            _playerMovement.Dispose();
            
            _playerSprint.Dispose();
        }
        
        public void Tick(float deltaTime)
        {
            _playerInputsListener.Tick(deltaTime);
            
            _playerMovement.Tick(deltaTime);
            
            _playerView.Tick(deltaTime);
        }
    }
}