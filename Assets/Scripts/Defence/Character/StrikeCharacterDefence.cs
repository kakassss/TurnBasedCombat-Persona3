using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "StrikeCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/StrikeCharacterDefence")]
    public class StrikeCharacterBaseDefence : CharacterBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}