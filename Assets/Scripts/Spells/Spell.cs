using System;
using UnityEngine.UI;

[Serializable]
public class Spell
{
    public bool isInstantCast;
    public bool isFree;
    public int[] resourcesCost;
    public int[] resourcesGeneration;
    public float startingCastSpeed;
    public ResourceCostType[] resourceCostTypes;
    public Image spellImage;
}

public enum ResourceCostType
{
    Mana,
    Energy,
    Rage,
    ChaosShards,
    Maelstrom,
    Insanity,
    Focus,
    AstralPower,
    Fury,
    Pain,
    Health
}