using System.Collections;
using System.Collections.Generic;
using Battle.Action;
using SignalBus;
using UnityEngine;

namespace ShadowAI
{
    public sealed class ShadowActionAI : MonoBehaviour
    {
        [SerializeField] private BattleDataProvider _data;

        private List<InterfaceWrapperIAttack> _shadowAttacks = new List<InterfaceWrapperIAttack>();
        private List<InterfaceWrapperIAbility> _shadowAbilities = new List<InterfaceWrapperIAbility>();

        private Coroutine shadowActionCor;
    
        private EventBinding<OnShadowTurn> _shadowAction;

        private void OnEnable()
        {
            EnableEventBus();
        }
    
        private void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _shadowAction = new EventBinding<OnShadowTurn>(SetMoves);
            EventBus<OnShadowTurn>.Subscribe(_shadowAction);
        }
    
        private void DisableEventBus()
        {
            EventBus<OnShadowTurn>.Unsubscribe(_shadowAction);
        }
    
        private void SetMoves()
        {
            _shadowAttacks = _data.GetActiveShadow().entity.EntityAttacks;
            _shadowAbilities = _data.GetActiveShadow().entity.EntityAbilities;
            
            shadowActionCor = StartCoroutine(IEShadowAction());
            //IEShadowAction();
        }

        private IEnumerator IEShadowAction()
        {
            yield return new WaitForSeconds(0.5f);
            
            var randomAction = Random.Range(0, 2);// Currently there are only two actions.
            
            if (randomAction == 0)
            {
                var randomActionAttackMove = Random.Range(0, _shadowAttacks.Count);
                _shadowAttacks[randomActionAttackMove].Attack.AttackAction(_data.GetActiveShadow(),
                    _data.GetAllPersonas()); 
            }
            if(randomAction == 1)
            {
                var randomActionAbilityMove = Random.Range(0, _shadowAbilities.Count);
                _shadowAbilities[randomActionAbilityMove].Ability.AbilityAction(_data.GetActiveShadow(),
                    _data.GetAllPersonas());
            }
        }
    }
}
