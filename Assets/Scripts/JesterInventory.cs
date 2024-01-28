using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JesterInventory : MonoBehaviour
{
    [SerializeField] private List<Jester> SelectedJesters;
    [SerializeField] private int TroupeSize;
    [SerializeField] private int RemovedPerformers;

    [SerializeField] public static JesterInventory Instance;

    [SerializeField] private InventoryScroll[] AuditionScrolls;
    [SerializeField] private CustomizationScroll[] CustomizationScrolls;
    [SerializeField] private PerformanceScroll[] PerformanceScrolls;

    [SerializeField] private List<Item> Items;

    [SerializeField] private GameObject AuditionUI, CustomizationUI, PerformanceUI;
    [SerializeField] private TMP_Text CharacterMessageBox;

    [SerializeField] private float CardAnimationTimer;

    private void Start()
    {
        Instance = this;
        // EnableAuditionUI();
    }

    public bool AddJester(Jester jester)
    {
        if (SelectedJesters.Count < TroupeSize)
        {
            bool spotFound = false;
            for (int i = 0; i < TroupeSize; i++)
            {
                if (!AuditionScrolls[i].CheckForJester() && !spotFound)
                {
                    SelectedJesters.Insert(i, jester);
                    AuditionScrolls[i].SetJester(jester);
                    spotFound = true;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public Jester GetJester(int index)
    {
        return SelectedJesters[index];
    }

    public Item GetJestersItem(int index)
    {
        return CustomizationScrolls[index].GetItem();
    }

    public void RemoveJester(int slotIndex)
    {
        Jester jesterToRemove = AuditionScrolls[slotIndex].GetJester();
        SelectedJesters.Remove(jesterToRemove);
        AuditionScrolls[slotIndex].SetJester(null);
        FindObjectOfType<AuditionScreen>().ReturnJester(jesterToRemove);
    }

    public void EnableAuditionUI()
    {
        AuditionUI.SetActive(true);
        CustomizationUI.SetActive(false);
        PerformanceUI.SetActive(false);
    }

    public void EnableCustomizationUI()
    {
        // set up customization scrolls with jesters
        for (int i = 0; i < TroupeSize; i++)
        {
            CustomizationScrolls[i].SetJester(AuditionScrolls[i].GetJester());
        }
        AuditionUI.SetActive(false);
        CustomizationUI.SetActive(true);
        PerformanceUI.SetActive(false);
    }

    public void EnablePerformanceUI()
    {
        // set up customization scrolls with jesters
        for (int i = 0; i < TroupeSize; i++)
        {
            PerformanceScrolls[i].SetJester(AuditionScrolls[i].GetJester());
        }
        AuditionUI.SetActive(false);
        CustomizationUI.SetActive(false);
        PerformanceUI.SetActive(true);
    }

    public List<Item> GetItemList()
    {
        return Items;
    }

    public void GoToCustomization()
    {
        if (SelectedJesters.Count == TroupeSize)
        {
            EnableCustomizationUI();
            ScreenManager.Instance.ShowCustomizationScreen();
        }
    }

    public void GoToPerformance()
    {
        RemovedPerformers = 0;
        CustomizationUI.SetActive(false);
        ScreenManager.Instance.ShowPerformanceScreen();
    }

    public void GoToAudition()
    {
        // need to refresh slots
        EnableAuditionUI();
        ScreenManager.Instance.ShowAuditionScreen();
    }

    public IEnumerator ShowFeedback(int index, int score, bool successfulPerformance)
    {
        string chosenLine;
        // lines
        if (successfulPerformance)
        {
            // success and scored means successful performance
            if (score > 0)
            {
                chosenLine = SelectedJesters[index - RemovedPerformers].FetchRandomSuccessfulPerformanceLine();
            }
            // otherwise unscathed
            else
            {
                chosenLine = SelectedJesters[index - RemovedPerformers].FetchRandomUnscathedPerformanceLine();
            }
        }
        else
        {
            if (score > 0)
            {
                chosenLine = SelectedJesters[index - RemovedPerformers].FetchRandomUnscathedPerformanceLine();
            }
            if (score == 0)
            {
                chosenLine = SelectedJesters[index - RemovedPerformers].FetchRandomScathedPerformanceLines();
            }
            else
            {
                chosenLine = SelectedJesters[index - RemovedPerformers].FetchRandomDeathLine();
                // SelectedJesters.Remove(SelectedJesters[index]);
                // RemovedPerformers++;
                PerformanceScrolls[index].MarkAsExecuted();
            }
        }

        // updating the banner reaction
        PerformanceScrolls[index].SetReactionSprite(score);
        CharacterMessageBox.text = chosenLine;
        PerformanceScrolls[index].PlayHighlightAnimation();
        yield return new WaitForSeconds(CardAnimationTimer);
    }
}
