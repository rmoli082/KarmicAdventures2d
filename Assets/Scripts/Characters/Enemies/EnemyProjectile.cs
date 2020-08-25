using System.Collections;
using UnityEngine;

/// <summary>
/// Handle the projectile launched by the player to fix the robots.
/// </summary>
public class EnemyProjectile : MonoBehaviour
{
    public int manaCost = 2;
    public int diceNumber = 4;
    public int damageDice = 4;
    public int numberOfTargets = 1;
    private int targetsHit;

    public GameObject projectileHitPrefab;

    //[HideInInspector]
    public int damageAmount;

    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        damageAmount = 0;
        rigidbody2d = GetComponent<Rigidbody2D>();
        for (int i = 0; i < diceNumber; i++)
        {
            damageAmount += Random.Range(1, damageDice + 1);
        }
        
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    public void Launch(Enemy enemy, Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        damageAmount += ((enemy.baseStats.GetStats("magic") - 10) / 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterSheet.charSheet.ChangeHealth((damageAmount));
            Instantiate(projectileHitPrefab, transform.position, Quaternion.identity);
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
