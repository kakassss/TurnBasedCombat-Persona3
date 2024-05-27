using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Battle.Action
{
    public class BattleDataPersona : MonoBehaviour
    {
        //Get reference All personas
        [SerializeField] private List<Persona> _allPersona;
    
        private List<IMove> _allPlayablePersonas = new List<IMove>(); // To select
        private List<IMove> _allPersonas = new List<IMove>(); // To shadow all foe attack
    
        private IMove _activePersona;
        private int _personaCount;
    
        private int _personaCurrentEntity;
        private int _personaTotalEntity;
    
        public List<IMove> GetAllPersonas()
        {
            return _allPersonas;
        }

        private void Awake()
        {
            SetPersonas();
        
        }

        private void SetPersonas()
        {
            foreach (var persona in _allPersona)
            {
                if (persona.isDisable == false)
                {
                    _allPlayablePersonas.Add(persona);
                }
            }

            _personaCount = _allPlayablePersonas.Count;
        }
    
        private void SetPersonaData()
        {
            _activePersona = _allPlayablePersonas[_personaCurrentEntity];
            BattleDataProvider.ActivePersonaIndex = _personaCurrentEntity;
        }
    
        private void SetActivePersona()
        {
            BattleData.ActiveEntity = _activePersona; 
            _personaTotalEntity = _personaCount -1;

            EventBus<OnPersonaTurn>.Fire(new OnPersonaTurn());
        }

        public void SwapCurrentPersona()
        {
            if (_personaCurrentEntity == _personaTotalEntity)
            {
                //ShadowTurn
            }

            if (_personaCurrentEntity < _personaTotalEntity)
            {
            
            }
        }
    
    }
}
