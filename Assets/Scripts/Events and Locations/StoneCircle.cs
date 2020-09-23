using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StoneCircle : MonoBehaviour
{
    public GameObject displayBox;
    public string levelToLoad;

    public void Yes()
    {
        Dictionary<Item, int> inventory = Inventory.inventory.GetItems();

        foreach (KeyValuePair<Item, int> keypair in inventory)
        {
            if (keypair.Key.itemID == 13)
            {
                Inventory.inventory.RemoveItem(keypair.Key);
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
