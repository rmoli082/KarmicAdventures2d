using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Consumable", menuName = "Items/Consumable")]
[Serializable]
public class Consumable : Item
{
    public enum ConsumableType { RESTORE_HP, RESTORE_MP, INCREASE_HP, INCREASE_MP }
    [SerializeField]
    private ConsumableType consumableType;
    [SerializeField]
    private int amount;
    
    public override void Use()
    {

        switch (consumableType)
        {
            case ConsumableType.INCREASE_HP:
                CharacterSheet.charSheet.baseStats.UpdateStats("hp", CharacterSheet.charSheet.baseStats.GetStats("hp") + amount);
                UIHealthBar.Instance.SetManaValue(CharacterSheet.charSheet.baseStats.GetStats("currentMP") / (float)CharacterSheet.charSheet.baseStats.GetStats("mp"));
                break;
            case ConsumableType.INCREASE_MP:
                CharacterSheet.charSheet.baseStats.UpdateStats("mp", CharacterSheet.charSheet.baseStats.GetStats("mp") + amount);
                UIHealthBar.Instance.SetManaValue(CharacterSheet.charSheet.baseStats.GetStats("currentMP") / (float)CharacterSheet.charSheet.baseStats.GetStats("mp"));
                break;
            case ConsumableType.RESTORE_HP:
                CharacterSheet.charSheet.ChangeHealth(amount);
                break;
            case ConsumableType.RESTORE_MP:
                CharacterSheet.charSheet.ChangeMP(amount);
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
