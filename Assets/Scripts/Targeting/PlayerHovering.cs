using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace WoW.Targeting
{
    public class PlayerHovering : PlayerMouseOverbase
    {
        [Header("UI Prefab")]
        public GameObject targetInfoUIPrefab;
        public TextMeshProUGUI targetNameText;
        public TextMeshProUGUI targetHealthText;
        public TextMeshProUGUI targetLevelText;

        private void Update()
        {
            if (CanRaycast())
            {
                if (hit.transform.GetComponent<IHoverable>() != null && Cursor.visible == true)
                {
                    targetInfo = hit.transform.GetComponent<IHoverable>().GetTargetInfo();

                    VisualizeInfoInUI();
                }
                else
                {
                    DeVisualizeInfoInUI();
                }
            }
        }

        private void DeVisualizeInfoInUI()
        {
            if (targetInfoUIPrefab == null) { return; }
            targetInfoUIPrefab.SetActive(false);
        }

        private void VisualizeInfoInUI()
        {
            if (targetInfoUIPrefab == null) { return; }
            if (targetInfoUIPrefab.active == false) { targetInfoUIPrefab.SetActive(true); }
            targetNameText.text = string.Format(targetInfo.targetName);
            targetHealthText.text = string.Format("Health - " + targetInfo.targetHealth.ToString());
            targetLevelText.text = string.Format("Level - " + targetInfo.targetLevel.ToString());
        }
    }
}