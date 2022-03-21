using UnityEngine;

namespace Combat.Gameplay
{
    public sealed class MovementStatusEffect : MonoBehaviour
    {
        private ICanMove _movement;
        private bool _hasActiveBonus;
        private float _originalSpeed;

        public void AddBonus(float bonus, float multiplier = 0f)
        {
            if (_hasActiveBonus)
            {
                return;
            }

            _originalSpeed = _movement.Speed;
            
            _movement.SetSpeed(_originalSpeed * bonus, multiplier);

            _hasActiveBonus = true;
        }
        
        public void RemoveBonus()
        {
            if (!_hasActiveBonus)
            {
                return;
            }
            
            _movement.SetSpeed(_originalSpeed);

            _hasActiveBonus = false;
        }
        
        private void Awake()
        {
            _movement = GetComponent<ICanMove>();
        }
    }
}
