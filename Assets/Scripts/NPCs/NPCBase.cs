using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.Targeting;

namespace WoW.NPC
{
    public abstract class NPCBase : MonoBehaviour, IHoverable, ITargetable
    {
        public string npcName = "";
        public int npcLevel = 1;

        public Color nPCResourceBarColor;
        public float nPCResourceMaxBarValue;
        public float nPCResourceCurrentValue;

        public float nPCHealthMaxValue;
        public float nPCHealthCurrentValue;

        public Transform nPCTransform;

        public TargetInfo GetTargetInfo()
        {
            return new TargetInfo(npcName, nPCHealthCurrentValue, npcLevel, nPCTransform);
        }

        public TargetDisplayInfo GetTargetDisplayInfo()
        {
            return new TargetDisplayInfo(nPCResourceBarColor, nPCResourceMaxBarValue, nPCResourceCurrentValue, nPCHealthMaxValue, nPCHealthCurrentValue, npcName, npcLevel, nPCTransform);
        }
    }
}