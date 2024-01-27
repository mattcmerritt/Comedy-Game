using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Jester : ScriptableObject
{
    public string Name;
    public List<HumorStat> HumorStats;
    [TextArea] public List<string> AuditionLines;
    [TextArea] public List<string> SuccessfulAuditionLines;
    [TextArea] public List<string> SuccessfulPerformanceLines;
    [TextArea] public List<string> UnscathedPerformanceLines;
    [TextArea] public List<string> ScathedPerformanceLines;
    [TextArea] public List<string> DeathLines;
}
