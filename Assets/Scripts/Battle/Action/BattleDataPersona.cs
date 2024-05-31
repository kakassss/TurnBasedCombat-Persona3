using System;
using System.Collections.Generic;
using System.Linq;
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
    
        private int _personaTotalCount;
        private int _personaCurrentEntity;
        private int _personaTotalPlayableCount;
        
        public List<IMove> GetAllPersonas()
        {
            return _allPersonas;
        }

        public int GetAllPersonaCount()
        {
            return _personaTotalCount;
        }
        
        public void InitPersona(List<Persona> allPersona)
        {
            SetPersonasList(allPersona);// Set total number of persona
            SetPlayablePersonaList(allPersona); // Set total playable number of persona
            
            SwapCurrentPersona();
        }
        
        private void SetPersonasList(List<Persona> allPersona)
        {
            foreach (var persona in allPersona)
            {
                _allPersonas.Add(persona);
            }
            
            _personaTotalCount = allPersona.Count;
        }

        public void SetPlayablePersonaList(List<Persona> allPersona)
        {
            _allPlayablePersonas.Clear(); // clear first data
            
            foreach (var persona in allPersona.Where(persona => persona.IsDisable == false))
            {
                _allPlayablePersonas.Add(persona); // add to list playable personas
            }

            _personaTotalPlayableCount = _allPlayablePersonas.Count; // set total number of playable persona
        }
        
        private void SetPlayablePersonas()
        {
            ActivePersona = _allPlayablePersonas[_personaCurrentEntity]; // Select current active persona and define
            
            for (int i = 0; i < _allPersonas.Count; i++)
            {
                if (_allPersonas[i] == _allPlayablePersonas[_personaCurrentEntity])
                {
                    BattleDataProvider.ActivePersonaIndex = i;
                }
            }
            //BattleDataProvider.ActivePersonaIndex = _personaCurrentEntity; // set current persona index
            
            BattleDataManager.ActiveEntity = ActivePersona;  // set current active entity to persona
            EventBus<OnPersonaTurn>.Fire(new OnPersonaTurn()); // fire event
        }

        public void ExtraMovePersona()
        {
            _personaCurrentEntity--;
        }

        public void SwapExtraMovePersona()
        {
            //if (_personaCurrentEntity >= _personaTotalPlayableCount) return;
            
            _personaCurrentEntity--;
            SetPlayablePersonas();
        }
        
        public void SwapCurrentPersona()
        {
            if (_personaCurrentEntity == _personaTotalPlayableCount)
            {
                _personaCurrentEntity = 0;
                EventBus<OnTurnEntity>.Fire(new OnTurnEntity()); //ShadowTurn
                return;
            }
    
            if (_personaCurrentEntity < _personaTotalPlayableCount)
            {
                SetPlayablePersonas();
                _personaCurrentEntity++;
            }
        }
    
    }
}
