using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SelectShadow;
using SignalBus;
using UnityEngine;

namespace Battle.Action
{
    public class BattleData : MonoBehaviour
    {
        public static IMove ActiveEntity;
        [SerializeField] private List<Shadow> _allShadows;
        [SerializeField] private List<Persona> _allPersona;
    
        private List<IMove> _iAllPersonas = new List<IMove>();
        private List<IMove> _iAllShadows = new List<IMove>();
        
        private IMove _activeEntity;
        private IMove _activePersona;
        private IMove _activeShadow;
    
        private int _personaCount;
        private int _shadowCount;
        private int _currentEntityRound;
        private int _currentEntity = 0;
    
        public IMove GetActivePersona => _activePersona;
        public IMove GetActiveShadow => _activeShadow;
        public IMove GetActiveEntity => _activeEntity;
    
        public int GetCurrentEntityCount()
        {
            return _currentEntityRound;
        }
        
        public List<IMove> GetAllPersonas()
        {
            return _iAllPersonas;
        }
    
        public List<IMove> GetAllShadows()
        {
            return _iAllShadows;
        }
    
        private void Awake()
        {
            SetEntities();
        
            _personaCount = _allPersona.Count;
            _shadowCount = _allShadows.Count;
        
            SetPersonaData();
            SetActivePersona();
            SetShadowData();
        }
        
        private void SetEntities()
        {
            SetPersonas();
            SetShadows();
        }
        
        private void SetPersonas()
        {
            foreach (var persona in _allPersona)
            {
                _iAllPersonas.Add(persona);
            }
        }

        private void SetShadows()
        {
            foreach (var shadow in _allShadows)
            {
                _iAllShadows.Add(shadow);
            }
        }
        
        private void SetPersonaData()
        {
            _activePersona = _allPersona[_currentEntity];
            BattleDataProvider.ActivePersonaIndex = _currentEntity;
        }

        private void SetShadowData()
        {
            _activeShadow = _allShadows[_currentEntity];
            BattleDataProvider.ActiveShadowIndex = _currentEntity;
        }

        private void SetActivePersona()
        {
            _activeEntity = _activePersona; 
            _currentEntityRound = _personaCount -1;

            EventBus<OnPersonaTurn>.Fire(new OnPersonaTurn());
        }

        private void SetActiveShadow()
        {
            _activeEntity = _activeShadow;
            _currentEntityRound = _shadowCount -1;

            EventBus<OnShadowTurn>.Fire(new OnShadowTurn());
        }
    
        private void SetActiveEntity(IMove entity)
        {
            if (entity == _activePersona)
            {
                SetPersonaData();
                SetActivePersona();
            }
            else
            {
                SetShadowData();
                SetActiveShadow();
            }
        }
    
        public void SwapTurnCurrentEntity()
        {
            if (_currentEntity == _currentEntityRound)
            {
                _currentEntity = 0;
                SwapTurnToEnemy();
                return;
            }
        
            if (_currentEntity < _currentEntityRound)
            {
                _currentEntity++;
                SetActiveEntity(_activeEntity);
            }
        }
    
        public void SwapTurnToEnemy()
        {
            _activeEntity = _activeEntity == _activePersona ? _activeShadow : _activePersona;
            SetActiveEntity(_activeEntity);
        }
    }
}
