using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject {

    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public Item() { }

    public Item(Item item)
    {
        itemID = item.itemID;
        itemName = item.itemName;
        itemDescription = item.itemDescription;
        itemIcon = item.itemIcon;
    }

    public virtual void Use()
    {

    }

}
