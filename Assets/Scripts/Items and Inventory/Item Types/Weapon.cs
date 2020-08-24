using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Weapon", menuName ="Items/Weapon")]
public class Weapon : Item
{
    public int weaponID;

    public int attackDiceNumber;
    public int attackDiceAmount;
    
    private int damageAmount;

    public override void Use()
    {
        CharacterSheet.charSheet.EquipWeapon(this);
    }

    public int UseWeapon()
    {
        damageAmount = 0;
        for (int i = 0; i < attackDiceNumber; i++)
        {
            int add = Random.Range(1, (attackDiceAmount + 1));
            damageAmount += add;
        }
        return damageAmount;
    }

}
