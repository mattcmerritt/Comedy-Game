using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Jester : ScriptableObject
{
    // text elements for jester
    public string Name;
    public List<HumorStat> HumorStats; // a HumorStat has a enum value for type and a int for value
    [TextArea] public List<string> AuditionLines;
    [TextArea] public List<string> SuccessfulAuditionLines;
    [TextArea] public List<string> SuccessfulPerformanceLines;
    [TextArea] public List<string> UnscathedPerformanceLines;
    [TextArea] public List<string> ScathedPerformanceLines;
    [TextArea] public List<string> DeathLines;

    // visual information for jester
    public Sprite CostumeSprite;
    public Sprite IdleSprite;

    //audio information for jester (Spencer, Callandra, Kyle, Annie, Amari)
    public int VoiceBankNum;

    // functions to fetch random dialogue lines during gameplay
    public string FetchRandomAuditionLine()
    {
        return AuditionLines[Random.Range(0, AuditionLines.Count)];
    }

    public string FetchRandomSuccessfulAuditionLine()
    {
        return SuccessfulAuditionLines[Random.Range(0, SuccessfulAuditionLines.Count)];
    }

    public string FetchRandomSuccessfulPerformanceLine()
    {
        return SuccessfulPerformanceLines[Random.Range(0, SuccessfulPerformanceLines.Count)];
    }

    public string FetchRandomUnscathedPerformanceLine()
    {
        return UnscathedPerformanceLines[Random.Range(0, UnscathedPerformanceLines.Count)];
    }

    public string FetchRandomScathedPerformanceLines()
    {
        return ScathedPerformanceLines[Random.Range(0, ScathedPerformanceLines.Count)];
    }

    public string FetchRandomDeathLine()
    {
        return DeathLines[Random.Range(0, DeathLines.Count)];
    }
}
