using Interfaces;
using UnityEngine;

namespace Ability.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowAbility", menuName = "ScriptableObjets/ShadowAbility/StrikeShadowAbility")]
    public class StrikeShadowAbility : ShadowBaseAbilities
    {
        public override void AbilityAction(IMove activeEntity,IMove deactiveEntity)
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}