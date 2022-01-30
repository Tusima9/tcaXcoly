using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    ID,
    HP,
    MP,
    Attack,
    Defense,
    Skill,
}

[Serializable]
public class Statistic
{
    public StatType myStat;
    [SerializeField] private float currentValue;
    [SerializeField] private float maxValue = 50;

    public float Value
    {
        get => currentValue;
        set
        {
            if (value < 0)
                value = 0;

            if (value > maxValue)
                value = maxValue;

            currentValue = value;
        }
    }

    public float MaxValue { get => maxValue; set => maxValue = value; }

    public void Initialise()
    {
        Value = MaxValue;
    }

    public void ModifyValue(float amount)
    {
        Value += amount;
    }
}