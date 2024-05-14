using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "SlashCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/SlashCharacterDefence")]
    public class SlashCharacterBaseDefence : CharacterBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}