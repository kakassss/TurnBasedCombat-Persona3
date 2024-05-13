using UnityEngine;

public abstract class EntityBaseAbilities : ScriptableObject
{
    public string AbilityName;
    public Sprite AbilitySprite;
    
    [SerializeField] protected Stat _stat;
}