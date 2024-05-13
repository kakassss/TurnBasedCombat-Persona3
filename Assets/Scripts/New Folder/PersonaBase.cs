using UnityEngine;

[CreateAssetMenu(fileName = "PersonaBase", menuName = "ScriptableObjets/PersonaBase")]
public class PersonaBase : ScriptableObject
{
    public int Name;
    public int Level;
    
    public int Health;
    public int Mana;

    public GameObject Prefab;
}