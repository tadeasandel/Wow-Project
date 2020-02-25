using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.Attachments.Buffs;
using WoW.Attachments.Debuffs;

namespace WoW.Attachments
{
    public class AttachmentManager : MonoBehaviour
    {
        public float initialPositionX;
        public float initialPositionY;

        public float distanceX;
        public float distanceY;

        public int columnsInARow;

        public event Action onBuffChanged;
        public event Action onDebuffChanged;

        List<Buff> currentBuffs = new List<Buff>();
        List<Debuff> currentDebuffs = new List<Debuff>();

        private void OnEnable()
        {
            onBuffChanged += OnBuffChanged;
            onDebuffChanged += OnDebuffChanged;
        }

        private void OnDisable()
        {
            onBuffChanged -= OnBuffChanged;
            onDebuffChanged -= OnDebuffChanged;
        }

        private void OnDebuffChanged()
        {
            throw new NotImplementedException();
        }

        public void OnBuffChanged()
        {
            List<Buff> infiniteBuffs = new List<Buff>();
            Dictionary<int, float> durations = new Dictionary<int, float>();
            Dictionary<float, Buff> durationBuffs = new Dictionary<float, Buff>();
            foreach (Buff buff in currentBuffs)
            {
                if (buff.isInfinite)
                {
                    infiniteBuffs.Add(buff);
                }
                else
                {
                    durationBuffs.Add(buff.attachmentDuration, buff);
                }
            }
            
            List<Buff> sortedBuffs = new List<Buff>();
            float previoustimer = 0;
            Buff previousBuff;
            TimerResult smallResult;
            TimerResult previousResult;
            foreach (KeyValuePair<float,Buff> buff1 in durationBuffs)
            {
                foreach (KeyValuePair<float, Buff> buff2 in durationBuffs)
                {
                    if(buff1.Value == buff2.Value)
                    {
                        continue;
                    }
                    smallResult = CompareDebuffLengths(buff1.Value,buff2.Value);
                }
            }
        }
        public struct TimerResult
        {
            AttachmentBase winner;
            AttachmentBase looser;
            public TimerResult(AttachmentBase w, AttachmentBase l)
            {
                winner = w;
                looser = l;
            }
        }

        private TimerResult CompareDebuffLengths(AttachmentBase a, AttachmentBase b)
        {
            if (a.attachmentDuration > b.attachmentDuration)
            {
                return new TimerResult(a,b);
            }
            else if (a.attachmentDuration < b.attachmentDuration)
            {
                return new TimerResult(b,a);
            }
            else
            {
                return new TimerResult();
            }
        }

        public void AddBuff(Buff buff)
        {
            if (!buff.isStackable && currentBuffs.Contains(buff)) { return; }
            currentBuffs.Add(buff);
            onBuffChanged.Invoke();
        }

        public void RemoveBuff(Buff buff)
        {
            if (currentBuffs.Contains(buff))
            {
                currentBuffs.Remove(buff);
                onBuffChanged.Invoke();
            }
        }
    }
}