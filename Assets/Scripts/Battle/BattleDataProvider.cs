using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleDataProvider : MonoBehaviour
{
    public BattleData BattleData;
    
    public IMove GetActiveEntity()
    {
        return BattleData.GetActiveEntity;
    }
    
    public IMove GetDeactiveEntity()
    {
        return BattleData.GetDeactiveEntity;
    }
    
    public IMove GetPersona()
    {
        return BattleData.GetPersona;
    }
    
    public IMove GetShadow()
    {
        return BattleData.GetShadow;
    }
}
