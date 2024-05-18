namespace SignalBus
{
    public interface IEvent
    {
    
    }

    public struct OnHealthChanged : IEvent
    {
        public int ActiveEntity;
        public int DeactiveEntity;
    }

    public class OnMoveActionTurn : IEvent
    {
    
    }
}