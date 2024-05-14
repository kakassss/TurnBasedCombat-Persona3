using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "StrikeCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/StrikeCharacterDefence")]
    public class StrikeCharacterDefence : CharacterDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}