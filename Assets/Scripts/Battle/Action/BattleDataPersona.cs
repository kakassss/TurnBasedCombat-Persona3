using System;
using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
using UnityEngine;


namespace Battle.Action
{
    [Serializable]
    public class BattleDataPersona
    {
        public IMove ActivePersona;
    
        private List<IMove> _allPlayablePersonas = new List<IMove>(); // To select
        private List<IMove> _allPersonas = new List<IMove>(); // To shadow all foe attack
    
        private int _personaCount;
        private int _personaCurrentEntity;
        private int _personaTotalEntity;
        
        public List<IMove> GetAllPersonas()
        {
            return _allPersonas;
        }

        public int GetAllPersonaCount()
        {
            return _personaCount;
        }
        
        public void InitPersona(List<Persona> allPersona)
        {
            SetPersonasList(allPersona);
            
            SetPlayablePersonas();
        }
        
        private void SetPersonasList(List<Persona> allPersona)
        {
            foreach (var persona in allPersona)
            {
                _allPersonas.Add(persona);
                if (persona.isDisable == false)
                {
                    _allPlayablePersonas.Add(persona);
                }
            }

            _personaCount = _allPlayablePersonas.Count;
        }

        private void SetPlayablePersonas()
        {
            SetPersonaData();
            SetActivePersona();
        }
    
        private void SetPersonaData()
        {
            ActivePersona = _allPlayablePersonas[_personaCurrentEntity];
            BattleDataProvider.ActivePersonaIndex = _personaCurrentEntity;
        }
    
        private void SetActivePersona()
        {
            BattleDataManager.ActiveEntity = ActivePersona; 
            _personaTotalEntity = _personaCount -1;

            EventBus<OnPersonaTurn>.Fire(new OnPersonaTurn());
        }

        public void SwapCurrentPersona()
        {
            if (_personaCurrentEntity == _personaTotalEntity)
            {
                _personaCurrentEntity = 0;
                EventBus<OnTurnEntity>.Fire(new OnTurnEntity()); //ShadowTurn
                return;
            }

            if (_personaCurrentEntity < _personaTotalEntity)
            {
                _personaCurrentEntity++;
                SetPlayablePersonas();
            }
        }
    
    }
}
