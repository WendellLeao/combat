using UnityEngine;

namespace Combat.GameplaySystem.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Player _player;

        [Header("References")] 
        [SerializeField] private Camera _mainCamera;

        public void Initialize()
        {
            _player.SetMainCamera(_mainCamera);
        }
        
        public void Dispose()
        {}

        public void Tick(float deltaTime)
        {
            _player.Tick(deltaTime);
        }
    }
}