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
        private List<IMove> _allShadows = new List<IMove>(); // To shadow all foe attack
        
        private int _shadowsTotalCount;
        private int _shadowCurrentEntity;
        private int _shadowTotalPlayableCount;
        
        public List<IMove> GetAllShadows()
        {
            return _allShadows;
        }

        //It needs total count of shadows not playables
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

        private void SetShadowsList(List<Shadow> allShadow)
        {
            foreach (var shadow in allShadow)
            {
                _allShadows.Add(shadow);
            }
            _shadowsTotalCount = allShadow.Count;
        }

        public void SetPlayableShadows(List<Shadow> allShadow)
        {
            _allPlayableShadows.Clear();
            
            foreach (var shadow in allShadow.Where(shadow => shadow.isDisable == false))
            {
                _allPlayableShadows.Add(shadow);
            }

            _shadowTotalPlayableCount = _allPlayableShadows.Count;
        }
        

        private void SetPlayableShadowsData()
        {
            SetShadowData();
        }

        private void SetPlayableShadows()
        {
            SetShadowData();
            SetActiveShadow();
        }
        
        private void SetShadowData()
        {
            ActiveShadow = _allPlayableShadows[_shadowCurrentEntity];
            BattleDataProvider.ActiveShadowIndex = _shadowCurrentEntity;
        }
        
        private void SetActiveShadow()
        {
            BattleDataManager.ActiveEntity = ActiveShadow;
            
            EventBus<OnShadowTurn>.Fire(new OnShadowTurn());
        }
        
        public void SwapCurrentShadow()
        {

            if (_shadowCurrentEntity == _shadowTotalPlayableCount)
            {
                _shadowCurrentEntity = 0;
                EventBus<OnTurnEntity>.Fire(new OnTurnEntity()); //Persona Turn
                return;
            }

            if (_shadowCurrentEntity < _shadowTotalPlayableCount)
            {
                SetPlayableShadows();
                _shadowCurrentEntity++;
            }
        }
        
    }
}
