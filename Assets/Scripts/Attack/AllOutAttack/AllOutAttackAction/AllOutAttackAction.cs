using Battle.Action;
using SignalBus;
using UnityEngine;

namespace Attack.AllOutAttack.AllOutAttackAction
{
    public class AllOutAttackAction : MonoBehaviour
    {
        [SerializeField] private BattleDataProvider _battleDataProvider;


        private void EnableAllOutAttack()
        {
            var allShadows = _battleDataProvider.GetAllShadows();

            foreach (var shadow in allShadows)
            {
                if (shadow.entity.isDisable == false) break;
            }
            //EventBus<OnAllOutAttack>.Fire(new OnAllOutAttack());
            

        }
        
        
        
    }
}
