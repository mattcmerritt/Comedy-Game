using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JokeCollection : ScriptableObject
{
    [SerializeField] private List<Joke> Jokes;

    public string GetRandomJokeLine(ComedyType type)
    {
        List<Joke> matchingType = Jokes.FindAll((j) => j.Type == type);
        return matchingType[Random.Range(0, matchingType.Count)].Content;
    }
}
