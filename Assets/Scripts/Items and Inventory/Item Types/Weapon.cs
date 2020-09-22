using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Weapon", menuName ="Items/Weapon")]
public class Weapon : Item
{
    public enum SpellEffect { NONE, FROST, FIRE, SHOCK, UNDEAD, HOLY}

    public int weaponID;

    public int attackDiceNumber;
    public int attackDiceAmount;

    public SpellEffect effect = SpellEffect.NONE;
    public int attackBoost;
    public int defenseBoost;
    public int magicBoost;
    public int specialBoost;
    
    private int damageAmount;

    public override void Use()
    {
        CharacterSheet.charSheet.EquipWeapon(this);
        CharacterSheet.charSheet.AdditiveModifier("attack", 2, attackBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("defense", 2, defenseBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("magic", 2, magicBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("special", 2, specialBoost, 0);
        Debug.Log($"{itemName} equipped");
    }

    public int UseWeapon(Enemy enemy)
    {
        damageAmount = 0;
        for (int i = 0; i < attackDiceNumber; i++)
        {
            int add = Random.Range(1, (attackDiceAmount + 1));
            damageAmount += add;
        }
        switch(effect)
        {
            case SpellEffect.FIRE:
                break;
            case SpellEffect.FROST:
                break;
            case SpellEffect.HOLY:
                if (enemy.CompareTag("Undead") || enemy.GetComponent<CustomTags>().HasTag("Undead"))
                {
                    damageAmount *= 2;
                    Debug.Log($"Damage doubled to {damageAmount}");
                }
                break;
            case SpellEffect.SHOCK:
                break;
            case SpellEffect.UNDEAD:
                break;
        }
        return damageAmount;
    }

}
