using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScroll : MonoBehaviour
{
    [SerializeField] private Jester Jester;
    [SerializeField] private Image JesterSprite;
    [SerializeField] private Image HumorIcon;
    [SerializeField] private GameObject RemoveButton;

    public void SetJester(Jester jester)
    {
        Jester = jester;
        SetScrollSprites(jester);
        ToggleRemoveButton(jester);
    }

    public Jester GetJester()
    {
        return Jester;
    }

    public bool CheckForJester()
    {
        return Jester != null;
    }

    public void SetScrollSprites(Jester jester)
    {
        if(jester == null)
        {
            JesterSprite.color = new Color(255, 255, 255, 0); // if the jester is null, make the sprite invisible
            HumorIcon.color = new Color(255, 255, 255, 0); // same for humor icons
        }
        else
        {
            JesterSprite.sprite = jester.IdleSprite;
            JesterSprite.color = new Color(255, 255, 255, 255);
            HumorIcon.sprite = jester.IdleSprite;
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
    }

    public void ToggleRemoveButton(Jester jester)
    {
        if(jester == null)
        {
            RemoveButton.SetActive(false);
        }
        else
        {
            RemoveButton.SetActive(true);
        }
    }
}
