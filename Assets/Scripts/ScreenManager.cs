using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject AuditionScreen, CustomizationScreen, PerformanceScreen;

    public static ScreenManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void ShowAuditionScreen()
    {
        AuditionScreen.SetActive(true);
        CustomizationScreen.SetActive(false);
        PerformanceScreen.SetActive(false);
    }

    public void ShowCustomizationScreen()
    {
        AuditionScreen.SetActive(false);
        CustomizationScreen.SetActive(true);
        PerformanceScreen.SetActive(false);
    }

    public void ShowPerformanceScreen()
    {
        AuditionScreen.SetActive(false);
        CustomizationScreen.SetActive(false);
        PerformanceScreen.SetActive(true);
    }
}
