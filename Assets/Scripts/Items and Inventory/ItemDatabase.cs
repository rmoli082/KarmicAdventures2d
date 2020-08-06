using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase: MonoBehaviour
{
    public static ItemDatabase itemDb;

    public List<Items> itemDbList;

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

        itemDbList = new List<Items>(Resources.LoadAll<Items>("Items"));
    }

    public Items GetItemByID(int itemID)
    {
        foreach (Items item in itemDbList)
        {
               if (item.itemID == itemID)
               {
                   return item;
               }
        }

        return null;
    }
}
