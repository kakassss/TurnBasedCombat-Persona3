using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class BattleDataProvider : MonoBehaviour
{
    public BattleData BattleData;
    
    public IMove GetActivePersona()
    {
        return BattleData.GetActivePersona;
    }
    
    public IMove GetActiveShadow()
    {
        return BattleData.GetActiveShadow;
    }

    public IMove GetActiveEntity()
    {
        return BattleData.GetActiveEntity;
    }

    public List<IMove> GetAllPersonas()
    {
        return BattleData.GetAllPersonas();
    }
    
    public List<IMove> GetAllShadows()
    {
        return BattleData.GetAllShadows();
    }
}
