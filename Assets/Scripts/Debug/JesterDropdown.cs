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
        AuditionButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomAuditionLine());
        SuccessfulAuditionButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomSuccessfulAuditionLine());
        SuccessfulPerformanceButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomSuccessfulPerformanceLine());
        UnscathedPerformanceButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomUnscathedPerformanceLine());
        ScathedPerformanceButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomScathedPerformanceLines());
        DeathButton.onClick.AddListener(() => TextWindow.text = ActiveJester.FetchRandomDeathLine());
    }

    public void ChangeJester(int choice)
    {
        ActiveJester = JesterList[choice];
    }
}
