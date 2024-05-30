using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Battle.Action
{
    public class BattleDataManager : MonoBehaviour
    {
        public static IMove ActiveEntity;

        private EventBinding<OnTurnEntity> _onTurnEntity;
        
        [SerializeField] private List<Shadow> _allShadows;
        [SerializeField] private List<Persona> _allPersona;
        
        private BattleDataPersona _battleDataPersona;
        private BattleDataShadow _battleDataShadow;
        
        
        public IMove GetActivePersona()
        {
            return _battleDataPersona.ActivePersona;
        }

        public IMove GetActiveShadow()
        {
            return _battleDataShadow.ActiveShadow;
        }
        
        public List<IMove> GetAllPersonas()
        {
            return _battleDataPersona.GetAllPersonas();
        }
    
        public List<IMove> GetAllShadows()
        {
            return _battleDataShadow.GetAllShadows();
        }

        public int GetShadowCount()
        {
            return _battleDataShadow.GetAllShadowCount();
        }
    
        private void Awake()
        {
            _battleDataPersona = new BattleDataPersona();
            _battleDataShadow = new BattleDataShadow();
            EnableEventBus();
            
            //Current Active entity is persona
            _battleDataPersona.InitPersona(_allPersona);
            _battleDataShadow.InitShadow(_allShadows);
        }

        private void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _onTurnEntity = new EventBinding<OnTurnEntity>(Swap);
            EventBus<OnTurnEntity>.Subscribe(_onTurnEntity);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnTurnEntity>.Unsubscribe(_onTurnEntity);
        }
        
        private void SetActiveEntity()
        {
            //Main idea: Every entities should do their own work,
            // manager is here just for the select the right data
            if (ActiveEntity == _battleDataPersona.ActivePersona)
            {
                _battleDataPersona.SetPlayablePersonaList(_allPersona);
                _battleDataPersona.SwapCurrentPersona();
            }
            else
            {
                _battleDataShadow.SetPlayableShadows(_allShadows);
                _battleDataShadow.SwapCurrentShadow();
            }
        }

        private void Swap()
        {
             ActiveEntity = ActiveEntity == _battleDataPersona.ActivePersona ?
                 _battleDataShadow.ActiveShadow : _battleDataPersona.ActivePersona; 
             
             SetActiveEntity();
        }
    
        public void SwapTurnToEnemy()
        {
            SetActiveEntity();
        }
    }
}
