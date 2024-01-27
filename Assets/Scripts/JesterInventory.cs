using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterInventory : MonoBehaviour
{
    [SerializeField] private List<Jester> SelectedJesters;
    [SerializeField] private int TroupeSize;

    [SerializeField] public static JesterInventory Instance;

    private void Start()
    {
        Instance = this;
    }

    public bool AddJester(Jester jester)
    {
        if (SelectedJesters.Count < TroupeSize)
        {
            SelectedJesters.Add(jester);
            return true;
        }
        else
        {
            return false;
        }
    }
}
