using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationScroll : MonoBehaviour
{
    [SerializeField] private Jester Jester;
    [SerializeField] private Item EquippedItem;
    [SerializeField] private Image JesterSprite;
    [SerializeField] private Image HumorIcon, ItemIcon;

    [SerializeField] private Sprite AbsurdismIcon, AnecdoteIcon, DarkIcon, ImprovIcon, PropIcon, PunIcon, SarcasmIcon, SlapstickIcon;

    [SerializeField] private Item NothingItem;
    
    void OnEnable()
    {
        UpdateItemSprite();
        JesterSprite.sprite = Jester.IdleSprite;
    }

    public void SetJester(Jester jester)
    {
        Jester = jester;
    }

    public Jester GetJester()
    {
        return Jester;
    }

    public void SetItem(Item item)
    {
        EquippedItem = item;
    }

    public Item GetItem()
    {
        return EquippedItem;
    }

    public void OnLeftPress()
    {
        List<Item> items = JesterInventory.Instance.GetItemList();
        EquippedItem = items[((items.IndexOf(EquippedItem)-1)+items.Count)%items.Count];
        UpdateItemSprite();
    }

    public void OnRightPress()
    {
        List<Item> items = JesterInventory.Instance.GetItemList();
        EquippedItem = items[((items.IndexOf(EquippedItem)+1)+items.Count)%items.Count];
        UpdateItemSprite();
    }

    public void UpdateItemSprite()
    {
        ItemIcon.sprite = EquippedItem.ItemImage;

        if(EquippedItem == NothingItem)
        {
            // make sprite invisible
            HumorIcon.color = new Color(255, 255, 255, 0);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Absurdist)
        {  
            HumorIcon.sprite = AbsurdismIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Anecdotal)
        {  
            HumorIcon.sprite = AnecdoteIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Dark)
        {  
            HumorIcon.sprite = DarkIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Improv)
        {  
            HumorIcon.sprite = ImprovIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Prop)
        {  
            HumorIcon.sprite = PropIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Puns)
        {  
            HumorIcon.sprite = PunIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Sarcastic)
        {  
            HumorIcon.sprite = SarcasmIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        else if(EquippedItem.HumorStat.Type == ComedyType.Slapstick)
        {  
            HumorIcon.sprite = SlapstickIcon; 
            HumorIcon.color = new Color(255, 255, 255, 255);
        }
        
    }

    // public void SetScrollSprites(Jester jester)
    // {
    //     if(jester == null)
    //     {
    //         JesterSprite.color = new Color(255, 255, 255, 0); // if the jester is null, make the sprite invisible
    //         HumorIcon.color = new Color(255, 255, 255, 0); // same for humor icons
    //     }
    //     else
    //     {
    //         JesterSprite.sprite = jester.IdleSprite;
    //         JesterSprite.color = new Color(255, 255, 255, 255);
    //         HumorIcon.sprite = jester.IdleSprite;
    //         HumorIcon.color = new Color(255, 255, 255, 255);
    //     }
    // }
}
