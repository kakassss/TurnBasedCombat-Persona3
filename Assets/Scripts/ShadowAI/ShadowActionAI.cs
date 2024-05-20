using System.Collections;
using System.Collections.Generic;
using SignalBus;
using UnityEngine;

public class ShadowActionAI : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _data;

    private List<InterfaceWrapperIAttack> _shadowAttacks = new List<InterfaceWrapperIAttack>();
    private List<InterfaceWrapperIAbility> _shadowAbilities = new List<InterfaceWrapperIAbility>();

    private int _maxShadowIndex;
    private Coroutine shadowActionCor;
    
    private EventBinding<OnShadowTurn> _shadowAction;
    
    protected virtual void OnEnable()
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

        _maxShadowIndex = _data.BattleData.GetCurrentEntityCount();
        shadowActionCor = StartCoroutine(IEShadowAction());
    }

    private IEnumerator IEShadowAction()
    {
        Debug.Log("shadow Action Start ");
        yield return new WaitForSeconds(0.3f);
            
        var randomAction = Random.Range(0, 2);// Currently there are only two actions.
        var randomActionMove = Random.Range(0, _shadowAttacks.Count);
        
        if (randomAction == 0)
        {
            _shadowAttacks[randomActionMove].Attack.AttackAction(_data.GetActiveShadow(),
                _data.GetAllPersonas());    
        }
        else
        {
            _shadowAbilities[randomActionMove].Ability.AbilityAction(_data.GetActiveShadow(),
                _data.GetAllPersonas());
        }
        
        Debug.Log("shadow Action end ");
    }
}
