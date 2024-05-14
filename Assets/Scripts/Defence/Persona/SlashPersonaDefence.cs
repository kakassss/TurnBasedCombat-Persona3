using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "SlashPersonaDefence", menuName = "ScriptableObjets/PersonaDefence/SlashPersonaDefence")]
    public class SlashPersonaDefence : PersonaBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}