using System;
using System.Collections.Generic;
using System.Linq;
using BaseEntity;
using Interfaces;
using SignalBus;

namespace Battle.Action
{
    [Serializable]
    public class BattleDataShadow
    {
        public IMove ActiveShadow;
        
        private List<IMove> _allPlayableShadows = new List<IMove>(); // To select
        private List<IMove> _allAliveShadows = new List<IMove>(); // To shadow all foe attack
        
        
        private int _shadowsTotalCount;
        private int _shadowCurrentEntity;
        private int _shadowTotalPlayableCount;
        
        public List<IMove> GetAllShadows()
        {
            return _allAliveShadows;
        }

        public int GetAllShadowCount()
        {
            return _shadowsTotalCount;
        }
        
        public void InitShadow(List<Shadow> allShadow)
        {
            SetShadowsList(allShadow);
            SetPlayableShadows(allShadow);
            
            SetPlayableShadowsData();
        }

        public void SetShadowsList(List<Shadow> allShadow)
        {
            _allAliveShadows.Clear();
            
            foreach (var shadow in allShadow.Where(shadow => shadow.IsDead == false))
            {
                _allAliveShadows.Add(shadow);
            }

            _shadowsTotalCount = allShadow.Count;
        }
        
        public void SetPlayableShadows(List<Shadow> allShadow)
        {
            _allPlayableShadows.Clear();
            
            foreach (var shadow in allShadow.Where(shadow => shadow.IsDisable == false && shadow.IsDead == false))
            {
                _allPlayableShadows.Add(shadow);
            }
            
            _shadowTotalPlayableCount = _allPlayableShadows.Count;
        }
        

        public void SetPlayableShadowsData()
        {
            SetShadowData();
        }

        private void SetPlayableShadowsWithSetShadow(List<Shadow> allShadow)
        {
            SetShadowsList(allShadow);
            SetShadowData();
            SetActiveShadow();
        }
        
        private void SetShadowData()
        {
            ActiveShadow = _allPlayableShadows[_shadowCurrentEntity];

            for (int i = 0; i < _allAliveShadows.Count; i++)
            {
                if (_allAliveShadows[i] == _allPlayableShadows[_shadowCurrentEntity])
                {
                    BattleDataProvider.ActiveShadowIndex = i;
                }
            }
        }
        
        private void SetActiveShadow()
        {
            BattleDataManager.ActiveEntity = ActiveShadow;
            EventBus<OnShadowTurn>.Fire(new OnShadowTurn());
        }
        
        public void SwapCurrentShadow(List<Shadow> allShadow)
        {
            if (_shadowCurrentEntity >= _shadowTotalPlayableCount)
            {
                _shadowCurrentEntity = 0;
                EventBus<OnTurnEntity>.Fire(new OnTurnEntity()); //Persona Turn
                return;
            }
            
            SetPlayableShadowsWithSetShadow(allShadow);
            _shadowCurrentEntity++;
        }
        
    }
}
