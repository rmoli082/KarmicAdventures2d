using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ItemQuest", menuName = "Quests/FindItem Quest")]
[Serializable]
public class FindItem : Quest
{
    public int numberNeeded;
    public int numberHeld;
    public Items itemRequired;

    public void RemoveItem()
    {
        Inventory.inventory.RemoveItem(itemRequired);
    }
}
