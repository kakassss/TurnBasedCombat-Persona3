using UnityEditor.Experimental.GraphView;

public interface IEvent
{
    
}

public struct OnHealthChanged : IEvent
{
    public int HealthPersona;
    public int HealthShadow;
}