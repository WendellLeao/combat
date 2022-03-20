using UnityEngine.InputSystem;
using Combat.Gameplay.Inputs;
using UnityEngine;
using System;

namespace Combat.Gameplay.Player
{
	[RequireComponent(typeof(Player))]
    public sealed class PlayerInputsListener : MonoBehaviour
    {
	    public event Action<PlayerInputsData> OnReadPlayerInputs;
		
		private PlayerInputs.LandControlsActions _playerLandControls;
		private PlayerInputs _playerInputs;
		private Vector2 _playerMovement;

		public void Initialize()
		{
			_playerInputs = new PlayerInputs();
		
			_playerInputs.Enable();

			_playerLandControls = _playerInputs.LandControls;
			
			SubscribeEvents();
		}

		public void Dispose()
		{
			_playerInputs.Disable();
			
			UnsubscribeEvents();
		}
		
		public void Tick(float deltaTime)
		{
			UpdatePlayerInputs();
		
			ResetInputs();
		}
	
		private void SubscribeEvents()
		{
			_playerLandControls.Movement.performed += SetPlayerMovement;
		}

		private void UnsubscribeEvents()
		{
			_playerLandControls.Movement.performed -= SetPlayerMovement;
		}

		private void UpdatePlayerInputs()
		{
			OnReadPlayerInputs?.Invoke(SetPlayerInputsData());
		}
	
		private void ResetInputs()
		{ }

		private PlayerInputsData SetPlayerInputsData()
		{
			PlayerInputsData playerInputsData = new PlayerInputsData();

			playerInputsData.PlayerMovement = _playerMovement;

			return playerInputsData;
		}

		private void SetPlayerMovement(InputAction.CallbackContext action)
		{
			_playerMovement = action.ReadValue<Vector2>();
		} 
    }
}