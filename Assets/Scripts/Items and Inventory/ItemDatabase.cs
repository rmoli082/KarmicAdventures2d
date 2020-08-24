using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase: MonoBehaviour
{
    public static ItemDatabase itemDb;

    public List<Item> itemDbList;

    void Awake() 
    {
        if (itemDb == null)
        {
            itemDb = this.GetComponent<ItemDatabase>();
        }
        else if (itemDb != this)
        {
            Destroy(gameObject);
        }

        itemDbList = new List<Item>(Resources.LoadAll<Item>("Items"));
    }

    public Item GetItemByID(int itemID)
    {
        foreach (Item item in itemDbList)
        {
               if (item.itemID == itemID)
               {
                   return item;
               }
        }

        return null;
    }
}
