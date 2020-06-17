using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Items
{
    [SerializeField]
    private int heal;
    [SerializeField]
    private int healthUP;
    
    public override void Use()
    {
        GameObject player = GameManager.gm.data.player;
        RubyController playerHealth = player.GetComponent<RubyController>();

        playerHealth.ChangeHealth(heal);
        int maxHP = Player.player.baseStats.GetStats("hpmax"); 
        maxHP += healthUP;
        Player.player.baseStats.stats["hpmax"] = maxHP;
        Inventory.inventory.RemoveItem(this);
    }
}
