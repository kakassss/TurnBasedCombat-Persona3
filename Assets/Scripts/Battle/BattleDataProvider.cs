using Interfaces;
using UnityEngine;

public class BattleDataProvider : MonoBehaviour
{
    [SerializeField] private BattleData _data;
    
    public IMove GetActiveEntity()
    {
        return _data.GetActiveEntity;
    }
    
    public IMove GetDeactiveEntity()
    {
        return _data.GetDeactiveEntity;
    }
    
    public IMove GetPersona()
    {
        return _data.GetPersona;
    }
    
    public IMove GetShadow()
    {
        return _data.GetShadow;
    }
}
