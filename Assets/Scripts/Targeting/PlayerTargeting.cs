using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using WoW.NPC;

namespace WoW.Targeting
{
    public class PlayerTargeting : PlayerMouseOverbase
    {
        [Header("Target Display Info")]
        public GameObject targetDisplayInfoUIPrefab;
        public TextMeshProUGUI targetNameText;
        public Image targetHealthBar;
        public Image targetResourceBar;
        public Transform targetTransform;

        TargetDisplayInfo targetDisplayInfo;

        public TargetDisplayInfo GetNewTarget()
        {
            if (CanRaycast())
            {
                if (hit.transform.GetComponent<ITargetable>() != null)
                {
                    return hit.transform.GetComponent<NPCBase>().GetTargetDisplayInfo();
                }
                else
                {
                    return GetEmptyTargetDisplayInfo();
                }
            }
            return GetEmptyTargetDisplayInfo();
        }

        public void SetNewTarget()
        {
            targetDisplayInfo = GetNewTarget();
            if (targetDisplayInfo.targetName != "")
            {
                VisualizeTargetInUI();
            }
        }

        public void DeVisualizeTargetInUI()
        {
            if (targetDisplayInfoUIPrefab == null) { return; }
            targetDisplayInfoUIPrefab.SetActive(false);
        }

        public void VisualizeTargetInUI()
        {
            if (targetDisplayInfoUIPrefab == null) { return; }
            if (targetDisplayInfoUIPrefab.active == false) { targetDisplayInfoUIPrefab.SetActive(true); }
            targetNameText.text = targetDisplayInfo.targetName;
            targetResourceBar.color = targetDisplayInfo.targetResourceBarColor;
            targetResourceBar.GetComponent<RectTransform>().localScale = new Vector3(CalculateScale(targetDisplayInfo.targetResourceCurrentValue, targetDisplayInfo.targetResourceMaxValue), 1, 1);
            targetHealthBar.GetComponent<RectTransform>().localScale = new Vector3(CalculateScale(targetDisplayInfo.targetHealthCurrentValue, targetDisplayInfo.targetHealthMaxValue), 1, 1);
        }

        public float CalculateScale(float currentScale, float maxScale)
        {
            return (maxScale - currentScale) / maxScale;
        }

        private TargetDisplayInfo GetEmptyTargetDisplayInfo()
        {
            return new TargetDisplayInfo(Color.black, -1, -1, -1, -1, "", 0, null);
        }
    }
}
