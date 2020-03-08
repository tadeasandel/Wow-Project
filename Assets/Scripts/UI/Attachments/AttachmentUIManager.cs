using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.Attachments;
using WoW.Attachments.Buffs;

namespace WoW.UI.Attachments
{
    public class AttachmentUIManager : MonoBehaviour
    {
        int currentAmountOfAttachments;
        AttachmentManager attachmentManager;

        List<GameObject> buffGameObjects;

        private void Awake()
        {
            attachmentManager = FindObjectOfType<AttachmentManager>();
        }

        public void RefreshBuffs(List<Buff> buffList)
        {
            
        }

        public void UpdatePositionOfAttachment(AttachmentBase attachment)
        {
            RectTransform buffRectTransform = attachment.GetComponent<RectTransform>();
            if (buffRectTransform != null)
            {
                buffRectTransform.position = new Vector3(attachment.uIXPosition, attachment.uIYPosition, 1);
            }
        }
    }
}