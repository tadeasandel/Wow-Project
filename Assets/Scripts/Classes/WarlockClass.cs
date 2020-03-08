using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockClass : MonoBehaviour
{
    public ClassType classType = ClassType.Warlock;
    [Header("Spell List")]
    public DamageSpell chaosBolt;
    public DamageOverTimeSpell immolate;

}
