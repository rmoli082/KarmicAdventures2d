using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemSave
{

    public int itemID;
    public string itemName;

    public ItemSave()
    {

    }

    public ItemSave(Item item)
    {
        itemID = item.itemID;
        itemName = item.itemName;
    }

}
