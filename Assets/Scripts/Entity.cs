using System.Collections.Generic;
using EntityData;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour, IActiveEntity
{
    [FormerlySerializedAs("_entityBase")] [SerializeField] private EntityBaseSO entityBaseSo;
    
    public int currentHealth;
    public int currentMana;
    
    [Header("Stats")]
    public List<InterfaceWrapperIAbility> EntityAbilities;
    public List<InterfaceWrapperIAttack> EntityAttacks;
    public List<InterfaceWrapperIDefence> EntityDefences;
    
    public abstract void MoveAction();
}