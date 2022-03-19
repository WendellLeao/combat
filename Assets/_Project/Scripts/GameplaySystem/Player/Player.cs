using UnityEngine;

namespace Combat.GameplaySystem.Player
{
    public sealed class Player : MonoBehaviour
    {
        [Header("Player Components")]
        [SerializeField] private PlayerMovement _playerMovement;

        public void Tick(float deltaTime)
        {
            _playerMovement.Tick(deltaTime);
        }

        public void SetMainCamera(Camera mainCamera)
        {
            _playerMovement.SetMainCamera(mainCamera);
        }
    }
}