using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IActiveEntity
{
    [SerializeField] private EntityBase _entityBase;
    
    public int currentHealth;
    public int currentMana;
    
    [Header("Stats")]
    public List<InterfaceWrapperIAbility> EntityAbilities;
    public List<InterfaceWrapperIAttack> EntityAttacks;
    public List<InterfaceWrapperIDefence> EntityDefences;
    
    public abstract void MoveAction();
}