using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.Attachments.Buffs;
using WoW.Attachments.Debuffs;
using WoW.UI.Attachments;

namespace WoW.Attachments
{
    public class AttachmentManager : MonoBehaviour
    {
        public float initialPositionX;
        public float initialPositionY;

        public float distanceX;
        public float distanceY;

        public int columnsInARow = 0;

        public event Action onBuffChanged;
        public event Action onDebuffChanged;

        public List<Buff> currentBuffs = new List<Buff>();
        public List<Debuff> currentDebuffs = new List<Debuff>();

        AttachmentUIManager attachmentUIManager;

        private void Awake()
        {
            attachmentUIManager = FindObjectOfType<AttachmentUIManager>();
        }

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
            List<Buff> durationBuffs = new List<Buff>();
            // sort infinite and timer based buffs
            foreach (Buff buff in currentBuffs)
            {
                if (buff.isInfinite)
                {
                    infiniteBuffs.Add(buff);
                }
                else
                {
                    durationBuffs.Add(buff);
                }
            }

            List<Buff> sortedBuffs = new List<Buff>();
            // add infinite buffs first to sortedbuffs list
            foreach (Buff buff in infiniteBuffs)
            {
                sortedBuffs.Add(buff);
            }
            // sort timer based buffs from lowest to highest
            float currentSmallestDebuff = Mathf.Infinity;
            int currentSmallestIndex = 0;
            for (int i = 0; i < durationBuffs.Count; i++)
            {
                for (int y = 0; i < durationBuffs.Count; y++)
                {
                    if (currentSmallestDebuff > durationBuffs[y].attachmentDuration)
                    {
                        currentSmallestDebuff = durationBuffs[y].attachmentDuration;
                        currentSmallestIndex = y;
                    }
                }
                sortedBuffs.Add(durationBuffs[currentSmallestIndex]);
                durationBuffs.RemoveAt(currentSmallestIndex);
            }
            float floatedSortedBuffsCount = sortedBuffs.Count;
            float floatedColumnsInARow = columnsInARow;
            int numberOfRows = (int)Math.Floor(floatedSortedBuffsCount / floatedColumnsInARow);
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int y = 0; y < columnsInARow; y++)
                {
                    sortedBuffs[columnsInARow].uIXPosition = initialPositionX + distanceX * y;
                    sortedBuffs[columnsInARow].uIYPosition = initialPositionY + distanceY * i;
                }
            }
            attachmentUIManager.RefreshBuffs(sortedBuffs);
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