using System.Collections;
using UnityEngine;

/// <summary>
/// Handle the projectile launched by the player to fix the robots.
/// </summary>
public class EnemyProjectile : MonoBehaviour
{
    public int diceNumber = 4;
    public int damageDice = 4;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("player") && !Player.player.isInvincible)
        {
            Debug.Log("Check");
            CharacterSheet.charSheet.ChangeHealth(-damageAmount);
        }

            Destroy(gameObject);
    }

}
