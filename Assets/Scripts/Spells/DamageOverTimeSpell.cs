using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using WoW.Attachments.Debuffs;

[Serializable]
public class DamageOverTimeSpell : DamageSpell
{
    public float tickDamage;
    public Debuff debuff;
}