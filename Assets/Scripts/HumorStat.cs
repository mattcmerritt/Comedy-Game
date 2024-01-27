using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComedyType
{
    Slapstick,
    Puns,
    Improv,
    Absurdist,
    Prop,
    Sarcastic,
    Anecdotal,
    Dark
}

[System.Serializable]
public class HumorStat
{
    public ComedyType Type;
    public int Value;
}
