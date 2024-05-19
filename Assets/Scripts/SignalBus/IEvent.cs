namespace SignalBus
{
    public interface IEvent
    {
    
    }

    public class OnHealthChanged : IEvent
    {
        public int ActiveEntity;
        public int DeactiveEntity;
    }

    public class OnMoveActionTurn : IEvent
    {
    
    }
}