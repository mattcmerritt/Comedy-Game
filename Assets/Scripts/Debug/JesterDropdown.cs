using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JesterDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown DropdownBox;
    [SerializeField] private Button AuditionButton, SuccessfulAuditionButton, SuccessfulPerformanceButton, UnscathedPerformanceButton, ScathedPerformanceButton, DeathButton;
    [SerializeField] private TMP_Text TextWindow;

    // needs to be relative to the resources folder
    [SerializeField] private string ResourcesPath;

    [SerializeField] private Jester[] JesterList;
    [SerializeField] private List<string> JesterNames;

    [SerializeField] private Jester ActiveJester;

    private void Awake()
    {
        // obtains all scriptable objects from the project of type Jester
        JesterList = Resources.LoadAll<Jester>(ResourcesPath);

        // currently prints Jester name and populates the dropdown
        JesterNames = new List<string>();
        for (int i = 0; i < JesterList.Length; i++)
        {
            Debug.Log($"Jester {JesterList[i].Name} was loaded.");
            JesterNames.Add(JesterList[i].Name);
        }

        DropdownBox.ClearOptions();
        DropdownBox.AddOptions(JesterNames);

        // activate the first jester
        ActiveJester = JesterList[0];

        // adding listeners for the buttons
        AuditionButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.AuditionLines.Count);
            TextWindow.text = ActiveJester.AuditionLines[lineChoice];
        });

        SuccessfulAuditionButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.SuccessfulAuditionLines.Count);
            TextWindow.text = ActiveJester.SuccessfulAuditionLines[lineChoice];
        });

        SuccessfulPerformanceButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.SuccessfulPerformanceLines.Count);
            TextWindow.text = ActiveJester.SuccessfulPerformanceLines[lineChoice];
        });

        UnscathedPerformanceButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.UnscathedPerformanceLines.Count);
            TextWindow.text = ActiveJester.UnscathedPerformanceLines[lineChoice];
        });

        ScathedPerformanceButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.ScathedPerformanceLines.Count);
            TextWindow.text = ActiveJester.ScathedPerformanceLines[lineChoice];
        });

        DeathButton.onClick.AddListener(() =>
        {
            int lineChoice = Random.Range(0, ActiveJester.DeathLines.Count);
            TextWindow.text = ActiveJester.DeathLines[lineChoice];
        });
    }

    public void ChangeJester(int choice)
    {
        ActiveJester = JesterList[choice];
    }
}
