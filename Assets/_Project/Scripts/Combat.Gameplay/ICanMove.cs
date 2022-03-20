namespace Combat.Gameplay
{
    public interface ICanMove
    {
        float Speed { get; }
        
        void Move(float deltaTime);
        void SetSpeed(float speed);
    }
}