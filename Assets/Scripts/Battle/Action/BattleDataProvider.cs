using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Battle.Action
{
    public class BattleDataProvider : MonoBehaviour
    {
        public BattleDataManager battleDataManager;

        public static int ActiveShadowIndex = 0;
        public static int ActivePersonaIndex = 0;
        
        
        public IMove GetActivePersona()
        {
            return battleDataManager.GetActivePersona();
        }
    
        public IMove GetActiveShadow()
        {
            return battleDataManager.GetActiveShadow();
        }

        public IMove GetActiveEntity()
        {
            return BattleDataManager.ActiveEntity;
        }
        
        public List<IMove> GetAllPersonas()
        {
            return battleDataManager.GetAllPersonas();
        }
        
        public List<IMove> GetAllShadows()
        {
            return battleDataManager.GetAllShadows();
        }


        public int GetShadowCount()
        {
            return battleDataManager.GetShadowCount();
        }
        
    }
}
