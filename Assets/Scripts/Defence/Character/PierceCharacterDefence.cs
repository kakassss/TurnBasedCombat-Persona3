using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "PierceCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/PierceCharacterDefence")]
    public class PierceCharacterDefence : CharacterDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}