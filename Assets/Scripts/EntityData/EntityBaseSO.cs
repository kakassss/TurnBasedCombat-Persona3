using UnityEngine;
using UnityEngine.Serialization;

namespace EntityData
{
    public abstract class EntityBaseSO : ScriptableObject
    {
        public string Name;
        public int Level;
    
        public int Health;
        public int Mana;

        public GameObject Prefab;

        public int BaseAttackValue;
        public int BaseAbilityValue;
        public int BaseDefenceValue;

        [HideInInspector] public float TotalPower;


        public void SetDatas()
        {
            TotalPower = Level * (BaseAttackValue + BaseAbilityValue + BaseDefenceValue);
        }

    }
}