using Combat.Gameplay.Player;
using UnityEngine;

namespace Combat.Gameplay
{
    public sealed class GameplaySystem : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private PlayerManager _playerManager;
        
        private void Awake()
        {
            _playerManager.Initialize();

            DisableCursor();
        }

        private void OnDestroy()
        {
            _playerManager.Dispose();
        }

        private void Update()
        {
            _playerManager.Tick(Time.deltaTime);
        }

        private void DisableCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}