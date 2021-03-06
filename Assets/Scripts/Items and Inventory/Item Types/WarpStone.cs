﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Warp Crystal", menuName = "Items/Warp Stone")]
public class WarpStone : Item
{
    public string locationName;
    public override void Use()
    {
       if (GameManager.gm.GetCurrentLocation().Equals(locationName))
        {
            if (QuestManager.questManager.GetQuestStatus(6) == Quest.QuestProgress.CURRENT)
            {
                Inventory.inventory.RemoveItem(this);
                GameManager.gm.EnterSubArea("WyrmBattle");
            }
            else
            {
                Inventory.inventory.RemoveItem(this);
                GameManager.gm.data.warpPopup.SetActive(true);
            }
            
        }
    }
}
