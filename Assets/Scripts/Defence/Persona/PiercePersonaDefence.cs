using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/PiercePersonaDefence")]
    public class PiercePersonaDefence : PersonaBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}