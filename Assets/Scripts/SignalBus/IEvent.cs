using Enums;
using Interfaces;

namespace SignalBus
{
    public interface IEvent
    {
    
    }

    public class OnHealthChanged : IEvent
    {
        
    }

    public class OnMoveActionTurn : IEvent
    {
    
    }

    public struct OnTakeDamage : IEvent
    {
        public IMove deactive;
        public Stat Stat;
    }
}