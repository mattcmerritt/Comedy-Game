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

    [SerializeField] private Sprite AbsurdismIcon, AnecdoteIcon, DarkIcon, ImprovIcon, PropIcon, PunIcon, SarcasmIcon, SlapstickIcon;

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
            
            foreach(HumorStat humorStat in jester.HumorStats)
            {
                if(jester.HumorStats[0].Type == ComedyType.Absurdist)
                {  
                    HumorIcon.sprite = AbsurdismIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Anecdotal)
                {  
                    HumorIcon.sprite = AnecdoteIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Dark)
                {  
                    HumorIcon.sprite = DarkIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Improv)
                {  
                    HumorIcon.sprite = ImprovIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Prop)
                {  
                    HumorIcon.sprite = PropIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Puns)
                {  
                    HumorIcon.sprite = PunIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Sarcastic)
                {  
                    HumorIcon.sprite = SarcasmIcon; 
                }
                else if(jester.HumorStats[0].Type == ComedyType.Slapstick)
                {  
                    HumorIcon.sprite = SlapstickIcon; 
                }
            }
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
