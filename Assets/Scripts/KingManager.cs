using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    public static KingManager Instance;

    [SerializeField] private List<HumorStat> RequiredHumor;
    [SerializeField] private SpriteRenderer KingSprite;

    [SerializeField] private List<Sprite> KingSprites;

    [SerializeField] private PerformanceScreen PerformanceScreen;

    private void Start()
    {
        GenerateNewKing();
        PerformanceScreen.SetKingPreferences(RequiredHumor);
    }

    public void GenerateNewPreferences()
    {
        List<HumorStat> newRequirements = new List<HumorStat>();
        List<ComedyType> remainingTypes = new List<ComedyType>() { 
            ComedyType.Slapstick, 
            ComedyType.Puns,
            ComedyType.Improv,
            ComedyType.Absurdist,
            ComedyType.Prop,
            ComedyType.Sarcastic,
            ComedyType.Anecdotal,
            ComedyType.Dark
        };

        int[] possibleValues = new int[] { -2, -1, 0, 1, 2 };
        int[] numberOfValues = new int[] { 2, 1, 2, 1, 2 }; // must add up to seven

        for (int i = 0; i < possibleValues.Length; i++)
        {
            while (numberOfValues[i] > 0)
            {
                // generating type of humor
                ComedyType type = remainingTypes[Random.Range(0, remainingTypes.Count)];
                remainingTypes.Remove(type);

                newRequirements.Add(new HumorStat { Type = type, Value = possibleValues[i] });
                numberOfValues[i]--;
            }
        }

        RequiredHumor = newRequirements;

    }

    public void ChangeKingSprite()
    {
        KingSprite.sprite = KingSprites[Random.Range(0, KingSprites.Count)];
    }

    public void GenerateNewKing()
    {
        GenerateNewPreferences();
        ChangeKingSprite();
    }

    public List<HumorStat> GetPreferences()
    {
        return RequiredHumor;
    }
}
