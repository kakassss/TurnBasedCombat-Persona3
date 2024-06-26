using System.Collections.Generic;
using Enums;
using Interfaces;

namespace SignalBus
{
    public interface IEvent
    {
    
    }

    public class OnTurnEntity : IEvent
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
        public int totalDamage;

        public int currentShadow;
    }

    public struct OnPersonaTakeDamage : IEvent
    {
        public IMove persona;
        public IMove shadow;
        public Stat Stat;
        public int totalDamage;

        public int currentPersona;
    }

    public struct OnAllShadowTakeDamage : IEvent
    {
        public IMove persona;
        public List<IMove> shadows;
        public Stat Stat;
        public int totalDamage;
        
        public int currentShadow;
    }
    
    public struct OnAllPersonaTakeDamage : IEvent
    {
        public IMove shadow;
        public List<IMove> personas;
        public Stat Stat;
        public int totalDamage;
        
        public int currentPersona;
    }

    public struct OnAllOutShadowTakeDamage : IEvent
    {
        public IMove persona;
        public List<IMove> shadows;
        public Stat Stat;
        public int totalDamage;
        
        public int currentShadow;
    }
    
    public struct OnShadowDefenceActionUI : IEvent
    {
        public string defenceType;
        public int totalDamage;
        public int activeShadowIndex;
    }

    public struct OnShadowAllOutDefenceActionUI : IEvent
    {
        
    }
    
    public struct OnPersonaDefenceActionUI : IEvent
    {
        public string defenceType;
        public int totalDamage;
        public int activePersonaIndex;
    }
    
    public struct OnShadowTargetChanged : IEvent
    {
        public int ActiveShadowIndex;
    }

    public struct OnAllOutAttack : IEvent
    {
        
    }

    public class OnCanAllOutAttack : IEvent
    {
        
    }

    public class OnShadowStunned : IEvent
    {
        public IMove shadow;
    }

    public class OnGameWin : IEvent
    {
        
    }

    public struct OnIsShadowDead : IEvent
    {
        public IMove shadow;
        public int activeShadowIndex;
    }

    public struct OnShadowDeadUI : IEvent
    {
        public IMove shadow;
        public int activeShadowIndex;
    }
    
}