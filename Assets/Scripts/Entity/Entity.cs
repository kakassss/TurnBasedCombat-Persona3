using System.Collections.Generic;
using EntityData;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entity
{
    public abstract class Entity : MonoBehaviour, IActiveEntity
    {
        [SerializeField] private EntityBaseSO entityBaseSo;
    
        public int CurrentHealth;
        public int CurrentMana;

        public float CurrentAttackPower;
        public float CurrentAbilityPower;
        public float CurrentDefencePower;
        
        
        [Header("Stats")]
        public List<InterfaceWrapperIAbility> EntityAbilities;
        public List<InterfaceWrapperIAttack> EntityAttacks;
        public List<InterfaceWrapperIDefence> EntityDefences;
        
        public virtual void SetEntityData()
        {
            entityBaseSo.SetDatas();
            
            CurrentHealth = entityBaseSo.Health;
            CurrentMana = entityBaseSo.Mana;

            CurrentAttackPower = (entityBaseSo.Level * entityBaseSo.BaseAttackValue) / 2;
            CurrentAbilityPower = (entityBaseSo.Level * entityBaseSo.BaseAbilityValue) / 2;
            CurrentDefencePower = (entityBaseSo.Level * entityBaseSo.BaseDefenceValue) / 2;
            
            Debug.Log("Entity name is " + entityBaseSo.Name);
            Debug.Log("Entity total power is " + entityBaseSo.TotalPower);
        }
        
        public abstract void MoveAction();
    }
}