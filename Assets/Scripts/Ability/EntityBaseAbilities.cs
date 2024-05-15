﻿using Enums;
using UnityEngine;

namespace Ability
{
    public abstract class EntityBaseAbilities : ScriptableObject
    {
        public string AbilityName;
        public Sprite AbilitySprite;
    
        [SerializeField] protected Stat _stat;
        [SerializeField] protected AttackTypes _attackTypes;
    }
}