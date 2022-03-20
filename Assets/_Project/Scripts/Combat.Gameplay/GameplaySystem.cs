﻿using Combat.Gameplay.Player;
using UnityEngine;

namespace Combat.Gameplay
{
    public sealed class GameplaySystem : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private PlayerController _playerController;
        
        private void Awake()
        {
            _playerController.Initialize();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDestroy()
        {
            _playerController.Dispose();
        }

        private void Update()
        {
            _playerController.Tick(Time.deltaTime);
        }
    }
}