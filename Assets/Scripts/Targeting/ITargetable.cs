using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoW.Targeting
{
    public interface ITargetable
    {
        TargetDisplayInfo GetTargetDisplayInfo();
    }
}