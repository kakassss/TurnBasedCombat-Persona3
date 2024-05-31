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
        private EventBinding<OnShadowStunned> _onShadowStunned;
        
        [SerializeField] private List<Shadow> _allShadows;
        [SerializeField] private List<Persona> _allPersona;
        
        private BattleDataPersona _battleDataPersona;
        private BattleDataShadow _battleDataShadow;
        
        private bool _personaExtraMove;
        
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
            _onTurnEntity = new EventBinding<OnTurnEntity>(SwapToEntity);
            EventBus<OnTurnEntity>.Subscribe(_onTurnEntity);

            _onShadowStunned = new EventBinding<OnShadowStunned>(PersonaExtraMove);
            EventBus<OnShadowStunned>.Subscribe(_onShadowStunned);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnTurnEntity>.Unsubscribe(_onTurnEntity);
            EventBus<OnShadowStunned>.Unsubscribe(_onShadowStunned);
        }
        
        private void PersonaExtraMove(OnShadowStunned shadow)
        {
            if (shadow.shadow.entity.IsStunned)
            {
                return;
            }
            
            _battleDataPersona.SetPlayablePersonaList(_allPersona);
            _battleDataPersona.SwapExtraMovePersona();
        }
        
        /*
         *  Target gösterme image mantıgı bozuk hala anlamsız
         *  2-3 satır zıplayabiliyor veya gösterilen düşmana vurmuyor
         */
        
        
        
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

        private void ResetIndexes()
        {
            BattleDataProvider.ActiveShadowIndex = 0;
            BattleDataProvider.ActivePersonaIndex = 0;
        }
        
        private void SwapToEntity()
        {
            ActiveEntity = ActiveEntity == _battleDataPersona.ActivePersona ?
                 _battleDataShadow.ActiveShadow : _battleDataPersona.ActivePersona;
            
            ShadowDisableStunning();
            ResetIndexes();     
            SetActiveEntity();
        }

        private void ShadowDisableStunning()
        {
            if (ActiveEntity != _battleDataPersona.ActivePersona) return;
            
            foreach (var shadow in _allShadows)
            {
                shadow.IsStunned = false;
                shadow.IsDisable = false;
            }
        }
    
        public void SwapTurn()
        {
            SetActiveEntity();
        }
    }
}
