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
		private bool _isSprinting;

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
			
			_playerLandControls.Sprint.performed += HandleSprint;
			_playerLandControls.Sprint.canceled += HandleSprint;
		}

		private void UnsubscribeEvents()
		{
			_playerLandControls.Movement.performed -= SetPlayerMovement;
			
			_playerLandControls.Sprint.performed -= HandleSprint;
			_playerLandControls.Sprint.canceled -= HandleSprint;
		}

		private void UpdatePlayerInputs()
		{
			OnReadPlayerInputs?.Invoke(SetPlayerInputsData());
		}

		private void HandleSprint(InputAction.CallbackContext context)
		{
			switch(context.phase)
			{
				case InputActionPhase.Performed:
				{
					_isSprinting = true;
					break;
				}
				case InputActionPhase.Canceled:
				{
					_isSprinting = false;
					break;
				}
			}
		}
		
		private void ResetInputs()
		{ }

		private PlayerInputsData SetPlayerInputsData()
		{
			PlayerInputsData playerInputsData = new PlayerInputsData();

			playerInputsData.PlayerMovement = _playerMovement;
			playerInputsData.IsSprinting = _isSprinting;

			return playerInputsData;
		}

		private void SetPlayerMovement(InputAction.CallbackContext action)
		{
			_playerMovement = action.ReadValue<Vector2>();
		} 
    }
}