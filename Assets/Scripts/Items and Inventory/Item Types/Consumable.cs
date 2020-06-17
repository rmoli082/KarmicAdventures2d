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
        GameManager.gm.startHealth += healthUP;
        Inventory.inventory.RemoveItem(this);
    }
}
