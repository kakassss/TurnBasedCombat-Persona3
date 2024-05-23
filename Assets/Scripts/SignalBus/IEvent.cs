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

    public class OnShadowTurn : IEvent
    {
        
    }

    public class OnPersonaTurn : IEvent
    {
        
    }

    public struct OnShadowTakeDamage : IEvent
    {
        public IMove persona;
        public IMove shadow;
        public Stat Stat;
        public string defenceType;
        public int totalDamage;
    }

    public struct OnPersonaTakeDamage : IEvent
    {
        public IMove persona;
        public IMove shadow;
        public Stat Stat;
        public string defenceType;
        public int totalDamage;
    }

    public struct OnTakeDamage : IEvent // TODO: SHADOW IMPLEMENT STILL NOT DONE
    {
        
    }

    public struct OnDefenceActionUI : IEvent
    {
        public string defenceType;
        public int totalDamage;
    }
}