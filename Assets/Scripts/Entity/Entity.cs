using System.Collections.Generic;
using EntityData;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace BaseEntity
{
    public abstract class Entity : MonoBehaviour, IEntity,IMove
    {
        public bool IsDisable;
        public bool IsStunned;
        
        public EntityBaseSO entityBaseSo;
        protected int _currentHealth;
        protected int _currentMana;

        protected float _currentAttackPower;
        protected float _currentAbilityPower;
        protected float _currentDefencePower;
        
        public int CurrentHealth => _currentHealth;

        public int GetHealth()
        {
            return _currentHealth;
        }
        public int CurrentMana => _currentMana;
        
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
            
            _currentHealth = entityBaseSo.Health;
            _currentMana = entityBaseSo.Mana;

            _currentAttackPower = (entityBaseSo.Level * entityBaseSo.BaseAttackValue) / 2;
            _currentAbilityPower = (entityBaseSo.Level * entityBaseSo.BaseAbilityValue) / 2;
            _currentDefencePower = (entityBaseSo.Level * entityBaseSo.BaseDefenceValue) / 2;
            
            //Debug.Log("Entity name is " + entityBaseSo.Name);
            //Debug.Log("Entity total power is " + entityBaseSo.TotalPower);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }

        public virtual void MoveAction()
        {
            EventBus<OnMoveActionTurn>.Fire(new OnMoveActionTurn());
        }
        
        public void TakeDamageUsingAttack(int damage)
        {
            _currentHealth -= damage;
        }

        public void Heal(int value)
        {
            _currentHealth += value;
        }

        public void IncreaseMana(int value)
        {
            _currentMana += value;
        }
        
        public void SpendMana(int value)
        {
            _currentMana -= value;
        }

        public Entity entity { get; set; }
    }
}