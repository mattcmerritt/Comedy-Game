using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterInventory : MonoBehaviour
{
    [SerializeField] private List<Jester> SelectedJesters;
    [SerializeField] private int TroupeSize;

    [SerializeField] public static JesterInventory Instance;

    [SerializeField] private InventoryScroll[] AuditionScrolls;
    [SerializeField] private CustomizationScroll[] CustomizationScrolls;

    [SerializeField] private List<Item> Items;

    [SerializeField] private GameObject AuditionUI, CustomizationUI;

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
    }

    public List<Item> GetItemList()
    {
        return Items;
    }

    public void GoToCustomization()
    {
        if(SelectedJesters.Count == TroupeSize)
        {
            EnableCustomizationUI();
        }
    }
}
