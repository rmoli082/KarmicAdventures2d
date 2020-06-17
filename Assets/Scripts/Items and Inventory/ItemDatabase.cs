using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase: MonoBehaviour
{
    public List<Items> itemDbList = new List<Items>();

    void Awake() 
    {
        
    }

    public string GetItemNameByID(int itemID)
    {
        foreach (Items item in itemDbList)
           {
               if (item.itemID == itemID)
               {
                   return item.itemName;
               }
           }
        return "Item not found";
    }
}
