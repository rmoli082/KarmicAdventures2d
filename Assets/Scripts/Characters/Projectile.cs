using System.Collections;
using UnityEngine;

/// <summary>
/// Handle the projectile launched by the player to fix the robots.
/// </summary>
public class Projectile : MonoBehaviour
{
    public int manaCost = 2;
    public int diceNumber = 4;
    public int damageDice = 4;
    public int numberOfTargets = 1;
    private int targetsHit;

    public GameObject projectileHitPrefab;

    //[HideInInspector]
    public float damageAmount;

    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        for (int i = 0; i < diceNumber; i++)
        {
            damageAmount += Random.Range(1, damageDice + 1);
        }
        damageAmount += ((CharacterSheet.charSheet.baseStats.GetStats("magic") - 10) / 2);
        if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Arcanist"))
        {
            for (int i = 0; i < CharacterSheet.charSheet.selectedSkills["Arcanist"]; i++)
            {
                damageAmount = Mathf.FloorToInt(damageAmount * 1.075f);
            }
        }
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        CharacterSheet.charSheet.ChangeMP(-manaCost);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.Damage(damageAmount);
            GameObject project = Instantiate(projectileHitPrefab, transform.position, Quaternion.identity);
            project.transform.parent = e.transform;
            targetsHit++;
            if (targetsHit == numberOfTargets)
            {
                Destroy(gameObject);
                return;
            }
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EnableCollider(this.gameObject.GetComponent<CircleCollider2D>()));
        }
    }

    IEnumerator EnableCollider(CircleCollider2D collider2D)
    {
        yield return new WaitForSeconds(0.5f);
        collider2D.enabled = true;
    }
}
