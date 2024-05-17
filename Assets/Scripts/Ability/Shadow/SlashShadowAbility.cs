using Interfaces;
using UnityEngine;

namespace Ability.Shadow
{
    [CreateAssetMenu(fileName = "SlashShadowAbility", menuName = "ScriptableObjets/ShadowAbility/SlashShadowAbility")]
    public class SlashShadowAbility : ShadowBaseAbilities
    {
        public override void AbilityAction(IMove activeEntity,IMove deactiveEntity)
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}