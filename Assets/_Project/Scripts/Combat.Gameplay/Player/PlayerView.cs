using UnityEngine;

namespace Combat.Gameplay.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [Header("Animations")]
        [SerializeField] private PlayerAnimationsController _playerAnimationsController;

        public void Initialize(PlayerMovement playerMovement)
        {
            _playerAnimationsController.Initialize(playerMovement);
        }

        public void Tick(float deltaTime)
        {
            _playerAnimationsController.Tick(deltaTime);
        }
    }
}