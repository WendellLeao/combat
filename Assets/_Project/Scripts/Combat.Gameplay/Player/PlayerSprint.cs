using Combat.Gameplay.Inputs;
using UnityEngine;

namespace Combat.Gameplay.Player
{
    [RequireComponent(typeof(Player))]
    public sealed class PlayerSprint : MonoBehaviour
    {
        [SerializeField] private MovementStatusEffect _movementStatusEffect;
        [SerializeField] private float _statusEffectBonus;
        [SerializeField] private float _timeMultiplier = 0.1f;

        private PlayerInputsListener _playerInputsListener;

        public void Initialize(PlayerInputsListener playerInputsListener)
        {
            _playerInputsListener = playerInputsListener;
            
            _playerInputsListener.OnReadPlayerInputs += HandleReadPlayerInputs;
        }
        
        public void Dispose()
        {
            _playerInputsListener.OnReadPlayerInputs -= HandleReadPlayerInputs;
        }

        private void HandleReadPlayerInputs(PlayerInputsData playerInputsData)
        {
            if (playerInputsData.IsSprinting)
            {
                _movementStatusEffect.AddBonus(_statusEffectBonus, _timeMultiplier);

                return;
            }
            
            _movementStatusEffect.RemoveBonus();
        }
    }
}
