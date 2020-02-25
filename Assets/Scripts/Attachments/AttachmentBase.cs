using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoW.Attachments
{
    public class AttachmentBase : MonoBehaviour
    {
        public string attachmentName;
        public float attachmentInitialDuration;
        public float attachmentDuration;
        public bool isStackable;
        public bool isInfinite;
    }
}