using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Jester : ScriptableObject
{
    public string Name;
    public List<HumorStat> HumorStats;
    public List<string> AuditionLines;
    public List<string> SuccessfulAuditionLines;
    public List<string> SuccessfulPerformanceLines;
    public List<string> UnscathedPerformanceLines;
    public List<string> ScathedPerformanceLines;
    public List<string> DeathLines;
}
