using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : ScriptableObject {

    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public Items() { }

    public Items(Items item)
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
