using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
[Serializable]
public class Consumable : Items
{
    [SerializeField]
    private int restoreHpAmount;
    [SerializeField]
    private int increaseMaxHP;
    [SerializeField]
    private int restoreMpAmount;
    [SerializeField]
    private int increaseMaxMP;
    
    public override void Use()
    {
        GameObject player = GameManager.gm.data.player;
        RubyController playerHealth = player.GetComponent<RubyController>();

        playerHealth.ChangeHealth(restoreHpAmount);
        if (increaseMaxHP > 0)
        {
            Player.player.baseStats.stats["hpmax"] += increaseMaxHP;
        }
        Inventory.inventory.RemoveItem(this);

        Debug.Log("Health: " + Player.player.baseStats.GetStats("hpnow") + "/" 
            + Player.player.baseStats.GetStats("hpmax"));
    }
}
