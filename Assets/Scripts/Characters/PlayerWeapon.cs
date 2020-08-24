using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Weapon weapon;
    public GameObject weaponHitPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            int damageAmount = weapon.UseWeapon();
            damageAmount += (CharacterSheet.charSheet.buffedStats.GetStats("attack") - 10) / 2;

            if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Weaponmaster"))
            {
                for (int i = 0; i < CharacterSheet.charSheet.selectedSkills["Weaponmaster"]; i++)
                {
                    damageAmount = Mathf.FloorToInt(damageAmount * 1.075f);
                }
            }

            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.Damage(damageAmount);
            Instantiate(weaponHitPrefab, other.transform.position, Quaternion.identity);

        }
    }
}
