using UnityEngine;

/// <summary>
/// Handle the projectile launched by the player to fix the robots.
/// </summary>
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //destroy the projectile when it reach a distance of 1000.0f from the origin
        if(transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    //called by the player controller after it instantiate a new projectile to launch it.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.Die();
        }
        
        Destroy(gameObject);
    }
}
