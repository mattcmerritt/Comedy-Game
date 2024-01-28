using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AuditionScreen : MonoBehaviour
{
    [SerializeField] private Jester CurrentJester;
    [SerializeField] private List<Jester> LoadedJesters;

    // needs to be relative to the resources folder
    [SerializeField] private string ResourcesPath;

    [SerializeField] private float RemainingTimer;
    [SerializeField] private TMP_Text TimerText;

    // for displaying the jester in the scene
    [SerializeField] private LoadedJester LoadedJester;

    [SerializeField] private TMP_Text Name, Line, Type;
    [SerializeField] private Image Icon;

    private void Awake()
    {
        // obtain all the jesters
        Jester[] jesterArray = Resources.LoadAll<Jester>(ResourcesPath);
        LoadedJesters = new List<Jester>(jesterArray);

        ShowRandomJester();
        UpdateJesterVisual();
    }

    private void Update()
    {
        // timer setup for later
        if (TimerText != null)
        {
            RemainingTimer -= Time.deltaTime;

            int minutes = Mathf.Clamp(((int)RemainingTimer / 60), 0, ((int)RemainingTimer / 60));
            int seconds = Mathf.Clamp(((int)RemainingTimer % 60), 0, ((int)RemainingTimer % 60));

            TimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    public Jester ShowRandomJester()
    {
        CurrentJester = LoadedJesters[Random.Range(0, LoadedJesters.Count)];
        return CurrentJester;
    }

    public void SkipJester()
    {
        Jester previousJester = CurrentJester;
        Jester newJester = ShowRandomJester();

        while (newJester == previousJester && LoadedJesters.Count != 1)
        {
            newJester = ShowRandomJester();
        }

        CurrentJester = newJester;

        // update UI elements
        UpdateJesterVisual();
    }

    public void RecruitJester()
    {
        bool added = JesterInventory.Instance.AddJester(CurrentJester);

        if (added)
        {
            LoadedJesters.Remove(CurrentJester);

            ShowRandomJester();

            // update UI elements
            UpdateJesterVisual();
        }
    }

    // updates the visual in the scene to reflect the new jester
    public void UpdateJesterVisual()
    {
        LoadedJester.LoadJester(CurrentJester, 0);
        Name.text = CurrentJester.Name;
        Type.text = CurrentJester.HumorStats[0].Type.ToString();
        Line.text = CurrentJester.FetchRandomAuditionLine();
        // icon stuff
    }

    // put a jester back in the recruitment pool (used by remove button)
    public void ReturnJester(Jester jester)
    {
        LoadedJesters.Add(jester);
    }
}
