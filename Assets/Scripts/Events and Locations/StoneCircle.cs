﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StoneCircle : MonoBehaviour
{
    public GameObject displayBox;
    public string levelToLoad;

    public void Yes()
    {
        List<Item> inventory = Inventory.inventory.GetItems();

        foreach (Item item in inventory)
        {
            if (item.itemID == 13)
            {
                Inventory.inventory.RemoveItem(item);
                displayBox.SetActive(false);
                GameManager.gm.EnterSubArea(levelToLoad);
                return;
            }
        }
    }

    public void No()
    {
        displayBox.SetActive(false);
    }
    
}
