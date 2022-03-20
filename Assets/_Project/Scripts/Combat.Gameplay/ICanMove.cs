namespace Combat.Gameplay
{
    public interface ICanMove
    {
        float Speed { get; set; }
        
        void Move(float deltaTime);
    }
}