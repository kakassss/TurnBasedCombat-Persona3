using UnityEngine;

public abstract class EntityBase : ScriptableObject
{
    public int Name;
    public int Level;
    
    public int Health;
    public int Mana;

    public GameObject Prefab; 
}