using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "SlashCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/SlashCharacterDefence")]
    public class SlashCharacterDefence : CharacterDefence
    {
        public Stat Stat => Stat.Slash;
        public DefenceTypes DefenceTypes => DefenceTypes.Reflect;
    
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}