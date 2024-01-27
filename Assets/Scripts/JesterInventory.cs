using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterInventory : MonoBehaviour
{
    [SerializeField] private List<Jester> SelectedJesters;
    [SerializeField] private int TroupeSize;

    [SerializeField] public static JesterInventory Instance;

    [SerializeField] private InventoryScroll[] Scrolls;

    private void Start()
    {
        Instance = this;
    }

    public bool AddJester(Jester jester)
    {
        if (SelectedJesters.Count < TroupeSize)
        {
            SelectedJesters.Add(jester);
            bool spotFound = false;
            for (int i = 0; i < TroupeSize; i++)
            {
                if (!Scrolls[i].CheckForJester() && !spotFound)
                {
                    Scrolls[i].SetJester(jester);
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
}
