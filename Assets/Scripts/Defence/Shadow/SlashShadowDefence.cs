using Interfaces;
using UnityEngine;

namespace Defence.Shadow
{
    [CreateAssetMenu(fileName = "SlashShadowDefence", menuName = "ScriptableObjets/ShadowDefence/SlashShadowDefence")]
    public class SlashShadowDefence : ShadowBaseDefence
    {
        public override void DefenceAction(IMove deactiveEntity)
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}