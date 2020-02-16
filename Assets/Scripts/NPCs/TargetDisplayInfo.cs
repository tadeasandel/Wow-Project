using UnityEngine;

public struct TargetDisplayInfo
{
    public Color targetResourceBarColor;
    public float targetResourceMaxValue;
    public float targetResourceCurrentValue;

    public float targetHealthMaxValue;
    public float targetHealthCurrentValue;

    public string targetName;
    public int targetLevel;

    public Transform targetTransform;

    public TargetDisplayInfo(Color resourceBarColor, float resourceMaxBarValue, float resourceCurrentValue, float healthMaxValue, float HealthCurrentValue, string name, int level, Transform currentTransform)
    {
        targetResourceBarColor = resourceBarColor;
        targetResourceMaxValue = resourceMaxBarValue;
        targetResourceCurrentValue = resourceCurrentValue;

        targetHealthMaxValue = healthMaxValue;
        targetHealthCurrentValue = HealthCurrentValue;

        targetName = name;
        targetLevel = level;

        targetTransform = currentTransform;
    }
}