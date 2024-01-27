using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScroll : MonoBehaviour
{
    [SerializeField] private Jester Jester;
    [SerializeField] private Image JesterSprite;

    public void SetJester(Jester jester)
    {
        Jester = jester;
        SetScrollSprite(jester);
    }

    public bool CheckForJester()
    {
        return Jester != null;
    }

    public void SetScrollSprite(Jester jester)
    {
        if(jester == null)
        {
            JesterSprite.color = new Color(255, 255, 255, 0); // if the jester is null, make the sprite invisible
        }
        else
        {
            JesterSprite.sprite = jester.IdleSprite;
            JesterSprite.color = new Color(255, 255, 255, 255);
        }
    }
}
