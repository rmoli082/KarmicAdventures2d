using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Weapon weapon;
    public GameObject weaponHitPrefab;
    public LayerMask layerMask;

    public Vector3 attackOffset;
    public float attackRange = 0.25f;

    private void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D other = Physics2D.OverlapCircle(pos, attackRange, layerMask);
        if (other != null)
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

            Instantiate(weaponHitPrefab, other.transform.position, Quaternion.identity);

            if (other.GetComponent<Enemy>().CompareTag("BlightCrystal"))
            {
                other.GetComponent<BlightCrystal>().CrystalHit();
            }
            else
            {
                other.GetComponent<Enemy>().Damage(damageAmount);
            }
            

            
        }

    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

}
