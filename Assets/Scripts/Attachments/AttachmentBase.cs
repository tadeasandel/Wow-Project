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
        private float _uIXPosition;
        public float UIXPosition
        {
            get
            {
                return _uIXPosition;
            }
            set
            {
                _uIXPosition = value;
            }
        }
        public float uIYPosition;
    }
}