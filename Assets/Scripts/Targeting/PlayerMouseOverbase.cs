using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoW.Targeting
{
    public class PlayerMouseOverbase : MonoBehaviour
    {
        protected RaycastHit hit;
        protected TargetInfo targetInfo;

        protected bool CanRaycast()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}