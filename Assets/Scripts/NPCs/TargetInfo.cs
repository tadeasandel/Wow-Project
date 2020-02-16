using UnityEngine;

public struct TargetInfo
{
    public string targetName;
    public float targetHealth;
    public int targetLevel;
    public Transform targetTransform;

    public TargetInfo(string name, float health,int level, Transform currentTransform)
    {
        targetName = name;
        targetHealth = health;
        targetLevel = level;
        targetTransform = currentTransform;
    }
}
