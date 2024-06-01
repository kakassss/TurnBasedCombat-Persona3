using Enums;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Defence.Shadow
{
    [CreateAssetMenu(fileName = "AllOutShadowDefence", menuName = "ScriptableObjets/ShadowDefence/AllOutShadowDefence")]
    public class AllOutShadowDefence : ShadowBaseDefence
    {
        public override void DefenceAction(IMove activeEntity, IMove deactiveEntity, Stat stat, int totalDamage, int currentEntityIndex)
        {
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowAllOutDefenceActionUI>.Fire(new OnShadowAllOutDefenceActionUI());
        }
    }
}
