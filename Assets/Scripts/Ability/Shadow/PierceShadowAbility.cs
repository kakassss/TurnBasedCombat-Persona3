using Interfaces;
using UnityEngine;

namespace Ability.Shadow
{
    [CreateAssetMenu(fileName = "PierceShadowAbility", menuName = "ScriptableObjets/ShadowAbility/PierceShadowAbility")]
    public class PierceShadowAbility : ShadowBaseAbilities
    {
        public override void AbilityAction(IMove activeEntity,IMove deactiveEntity)
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}