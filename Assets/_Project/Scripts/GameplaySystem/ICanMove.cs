namespace Combat.GameplaySystem
{
    public interface ICanMove
    {
        public float Speed { get; }
        
        public void Move(float deltaTime);
    }
}