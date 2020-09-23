using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : TreasureChest
{
    protected override void Start()
    {
       int id = this.chestID;
        while (ChestManager.chestManager.chestList.ContainsKey(id))
        {
            id = Random.Range(1, 193734);
            this.chestID = id;
            this.status = TreasureChest.ChestState.CLOSED;
        }
        dialogBox.SetActive(false);
        if (item.Length != 0)
        {
            itemChoice = Random.Range(0, item.Length);
        }
    }
    public void CreateLootbox(Item[] items, int coinAmount)
    {
        item = items;
        this.coinAmount = coinAmount;
    }

    public override void GetTreasure()
    {
        base.GetTreasure();
        Destroy(gameObject);
    }
}
