using UnityEngine;

namespace Combat.Gameplay.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Player _player;

        [Header("References")] 
        [SerializeField] private Camera _mainCamera;

        public void Initialize()
        {
            _player.Initialize(_mainCamera);
        }

        public void Dispose()
        {
            _player.Dispose();
        }

        public void Tick(float deltaTime)
        {
            _player.Tick(deltaTime);
        }
    }
}