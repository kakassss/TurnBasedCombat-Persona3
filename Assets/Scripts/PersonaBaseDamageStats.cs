using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaBaseDamageStats : ScriptableObject
{
    [Header("BasicAttacks BaseDamages")]
    public int SlashBaseDamage;
    public int StrikeBaseDamage;
    public int PierceBaseDamage;

    [Header("Skills BaseDamages")]
    public int FireBaseDamage;
    public int IceBaseDamage;
    public int ElectricityBaseDamage;
    public int WindBaseDamage;
    public int LightBaseDamage;
    public int DarkBaseDamage;
}
