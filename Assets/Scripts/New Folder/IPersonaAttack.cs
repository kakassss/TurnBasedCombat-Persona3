using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersonaAttack
{
    void Attack();
}

public interface IPersonaFireAttack : IPersonaAttack
{
    
}

public interface IPersonaIceAttack : IPersonaAttack
{

}