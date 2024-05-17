using System.Collections.Generic;
using EntityData;
using Interfaces;
using UnityEngine;


namespace BaseEntity
{
    public abstract class Entity : MonoBehaviour, IEntity,IMove
    {
        public EntityBaseSO entityBaseSo;
    
        public int CurrentHealth;
        public int CurrentMana;

        public float CurrentAttackPower;
        public float CurrentAbilityPower;
        public float CurrentDefencePower;
        
        
        [Header("Stats")]
        public List<InterfaceWrapperIAbility> EntityAbilities;
        public List<InterfaceWrapperIAttack> EntityAttacks;
        public List<InterfaceWrapperIDefence> EntityDefences;


        protected virtual void Awake()
        {
            entity = this;
            SetEntityData();
        }

        public virtual void SetEntityData()
        {
            entityBaseSo.SetDatas();
            
            
            CurrentHealth = entityBaseSo.Health;
            CurrentMana = entityBaseSo.Mana;

            CurrentAttackPower = (entityBaseSo.Level * entityBaseSo.BaseAttackValue) / 2;
            CurrentAbilityPower = (entityBaseSo.Level * entityBaseSo.BaseAbilityValue) / 2;
            CurrentDefencePower = (entityBaseSo.Level * entityBaseSo.BaseDefenceValue) / 2;
            
            //Debug.Log("Entity name is " + entityBaseSo.Name);
            //Debug.Log("Entity total power is " + entityBaseSo.TotalPower);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }

        public void TakeDamageUsingAttack(int damage)
        {
            CurrentHealth -= damage;
        }

        public void SpendMana(int value)
        {
            CurrentMana -= value;
        }

        public Entity entity { get; set; }
        public abstract void MoveAction(IMove activeEntity,IMove deactiveEntity);
    }
}