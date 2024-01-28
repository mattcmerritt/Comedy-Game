using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject AuditionScreen, CustomizationScreen, PerformanceScreen, MusicManager;

    public static ScreenManager Instance;

    [SerializeField] private VideoPlayer Cutscene;
    [SerializeField] private GameObject TavernBackground, ThroneRoomBackground, BackgroundCanvas;
    
    [SerializeField] private float TransitionDuration;


    private void Start()
    {
        Instance = this;
    }

    public void HideAll()
    {
        AuditionScreen.SetActive(false);
        CustomizationScreen.SetActive(false);
        PerformanceScreen.SetActive(false);

        BackgroundCanvas.SetActive(false);
    }

    public void ShowAuditionScreen()
    {
        AuditionScreen.SetActive(true);
        CustomizationScreen.SetActive(false);
        PerformanceScreen.SetActive(false);
        TavernBackground.SetActive(true);
        ThroneRoomBackground.SetActive(false);
        MusicManager.GetComponent<MusicManager>().SwitchMusic("Audition");
    }

    public void ShowCustomizationScreen()
    {
        AuditionScreen.SetActive(false);
        CustomizationScreen.SetActive(true);
        PerformanceScreen.SetActive(false);
    }

    public void ShowPerformanceScreen()
    {
        StartCoroutine(ThroneRoomTransition());
    }

    public IEnumerator ThroneRoomTransition()
    {
        Cutscene.Play();
        MusicManager.GetComponent<MusicManager>().SwitchMusic("Transition");
        yield return new WaitUntil(() => { return Cutscene.isPlaying; });
        HideAll();
        TavernBackground.SetActive(false);
        ThroneRoomBackground.SetActive(true);
        yield return new WaitForSeconds(TransitionDuration);
        MusicManager.GetComponent<MusicManager>().SwitchMusic("Performance");
        BackgroundCanvas.SetActive(true);
        AuditionScreen.SetActive(false);
        CustomizationScreen.SetActive(false);
        PerformanceScreen.SetActive(true);
    }
}
