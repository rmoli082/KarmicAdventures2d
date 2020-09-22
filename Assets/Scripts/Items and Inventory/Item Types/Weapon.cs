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
    public int weaponAttack;
    public int weaponMagic;
    public int weaponSpecial;
    public int attackBoost;
    public int defenseBoost;
    public int magicBoost;
    public int specialBoost;
    
    private int damageAmount;
    private Stats weaponStats;

    private void Awake()
    {
        weaponStats = new Stats();
        weaponStats.UpdateStats("attack", weaponAttack);
        weaponStats.UpdateStats("magic", weaponMagic);
        weaponStats.UpdateStats("special", weaponSpecial);
    }

    public override void Use()
    {
        CharacterSheet.charSheet.EquipWeapon(this);
        CharacterSheet.charSheet.AdditiveModifier("attack", 2, attackBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("defense", 2, defenseBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("magic", 2, magicBoost, 0);
        CharacterSheet.charSheet.AdditiveModifier("special", 2, specialBoost, 0);
        Debug.Log($"{itemName} equipped");
    }

    public int UseWeapon(MonoBehaviour caller, Enemy enemy)
    {
        CalculateDamage();
        ApplyEffect(caller, enemy);
        return damageAmount;
    }

    private void CalculateDamage()
    {
        damageAmount = 0;
        for (int i = 0; i < attackDiceNumber; i++)
        {
            int add = Random.Range(1, (attackDiceAmount + 1));
            damageAmount += add;
        }
        damageAmount += weaponStats.GetStats("attack") / 2;
    }

    private void ApplyEffect(MonoBehaviour caller, Enemy enemy)
    {
        float time;
        switch (effect)
        {
            case SpellEffect.FIRE:
                for (int i = 0; i <= weaponStats.GetStats("special") / 2; i++)
                {
                    int amount = Random.Range(1,3) + weaponStats.GetStats("magic") / 2;
                    time = (weaponStats.GetStats("magic") + weaponStats.GetStats("special")) / 3.0f;
                    caller.StartCoroutine(RepeatDamage(enemy, amount, time + (time * i)));
                }
                break;
            case SpellEffect.FROST:
                enemy.oldSpeed = enemy.speed;
                enemy.speed = 0f;
                time = (weaponStats.GetStats("magic") + weaponStats.GetStats("special")) / 2.5f;
                caller.StartCoroutine(Unfreeze(enemy, time));
                break;
            case SpellEffect.HOLY:
                if (enemy.CompareTag("Undead") || enemy.GetComponent<CustomTags>().HasTag("Undead"))
                {
                    damageAmount *= 2;
                    enemy.baseStats.UpdateStats("attack", enemy.baseStats.GetStats("attack") / 2);
                }
                break;
            case SpellEffect.SHOCK:
                for (int i = 0; i <= (weaponStats.GetStats("special") / 2) + 1; i++)
                {
                    int amount = Random.Range(1, 4) + (weaponStats.GetStats("magic") / 2);
                    time = (weaponStats.GetStats("magic") + weaponStats.GetStats("special")) / 1.5f;
                    caller.StartCoroutine(RepeatDamage(enemy, amount, time + (time * i)));
                }
                break;
            case SpellEffect.UNDEAD:
                break;
        }
    }

    IEnumerator RepeatDamage(Enemy enemy, int amount, float time)
    {
        yield return new WaitForSeconds(time);
        enemy.Damage(amount);
    }

    IEnumerator Unfreeze(Enemy enemy, float time)
    {
        yield return new WaitForSeconds(time);
        enemy.speed = enemy.oldSpeed;
    }
}
