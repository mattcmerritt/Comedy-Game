using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuditionScreen : MonoBehaviour
{
    [SerializeField] private Jester CurrentJester;
    [SerializeField] private List<Jester> LoadedJesters;

    // needs to be relative to the resources folder
    [SerializeField] private string ResourcesPath;

    private void Awake()
    {
        // obtain all the jesters
        Jester[] jesterArray = Resources.LoadAll<Jester>(ResourcesPath);
        LoadedJesters = new List<Jester>(jesterArray);
    }

    private void ShowRandomJester()
    {
        CurrentJester = LoadedJesters[Random.Range(0, LoadedJesters.Count)];
    }
}
