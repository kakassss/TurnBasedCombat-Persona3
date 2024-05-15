using UnityEngine;

namespace EntityData
{
    public abstract class EntityBaseSO : ScriptableObject
    {
        public int Name;
        public int Level;
    
        public int Health;
        public int Mana;

        public GameObject Prefab; 
    }
}