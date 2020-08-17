using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
[Serializable]
public class Consumable : Items
{
    public enum ConsumableType { RESTORE_HP, RESTORE_MP, INCREASE_HP, INCREASE_MP }
    [SerializeField]
    private ConsumableType consumableType;
    [SerializeField]
    private int amount;
    
    public override void Use()
    {
        GameObject player = GameManager.gm.data.player;
        RubyController playerHealth = player.GetComponent<RubyController>();

        switch (consumableType)
        {
            case ConsumableType.RESTORE_HP:
                playerHealth.ChangeHealth(amount);
                break;
            case ConsumableType.RESTORE_MP:
                Player.player.baseStats.stats["mpnow"] += amount;
                break;
            case ConsumableType.INCREASE_HP:
                Player.player.baseStats.stats["hpmax"] += amount;
                break;
            case ConsumableType.INCREASE_MP:
                Player.player.baseStats.stats["mpmax"] += amount;
                break;
        }
        Inventory.inventory.RemoveItem(this);
    }

    public void Init(int itemId, string itemName, string itemDesc, Sprite itemIcon, ConsumableType type, int amount)
    {
        this.itemID = itemId;
        this.itemName = itemName;
        this.itemDescription = itemDesc;
        this.itemIcon = itemIcon;
        this.consumableType = type;
        this.amount = amount;
    }
}
