using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationScroll : MonoBehaviour
{
    [SerializeField] private Jester Jester;
    [SerializeField] private Item EquippedItem;
    [SerializeField] private Image JesterSprite;
    [SerializeField] private Image JesterHumorIcon, ItemIcon;

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
