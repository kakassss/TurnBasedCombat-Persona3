using UnityEditor.Experimental.GraphView;

public interface IEvent
{
    
}

public struct OnHealthChanged : IEvent
{
    public int ActiveEntity;
    public int DeactiveEntity;
}