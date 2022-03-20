using UnityEngine;

namespace Combat.Gameplay
{
    public sealed class MovementStatusEffect : MonoBehaviour
    {
        private ICanMove _movement;
        private bool _hasActiveBonus;
        private float _originalSpeed;

        public void AddBonus(float bonus)
        {
            if (_hasActiveBonus)
            {
                return;
            }

            _originalSpeed = _movement.Speed;
            
            _movement.Speed *= bonus;

            _hasActiveBonus = true;
        }
        
        public void RemoveBonus()
        {
            if (!_hasActiveBonus)
            {
                return;
            }
            
            _movement.Speed = _originalSpeed;

            _hasActiveBonus = false;
        }
        
        private void Awake()
        {
            _movement = GetComponent<ICanMove>();
        }
    }
}
