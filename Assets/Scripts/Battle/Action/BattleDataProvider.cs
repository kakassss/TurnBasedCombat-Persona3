using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Battle.Action
{
    public class BattleDataProvider : MonoBehaviour
    {
        public BattleData BattleData;

        public static int ActiveShadowIndex = 0;
        public static int ActivePersonaIndex = 0;
        
        public int GetCurrentEntityCount()
        {
            return BattleData.GetCurrentEntityCount();
        }
        
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
}
