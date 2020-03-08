using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace WoW.Attachments
{
    [Serializable]
    public class AttachmentBase : MonoBehaviour
    {
        public string attachmentName;
        public float attachmentInitialDuration;
        public float attachmentDuration;
        public bool isStackable;
        public bool isInfinite;
        public float uIXPosition;
        public float uIYPosition;
        public float pandemicPercentage;
        public Image attachmentImage;
    }
}