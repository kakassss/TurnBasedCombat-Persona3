using UnityEngine;

namespace Ability.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowAbility", menuName = "ScriptableObjets/ShadowAbility/StrikeShadowAbility")]
    public class StrikeShadowAbility : ShadowBaseAbilities
    {
        public override void AbilityAction()
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}