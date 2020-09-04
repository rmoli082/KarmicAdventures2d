using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightCrystal : Enemy
{
    private enum State { First, Second, Third}
    public GameObject[] enemiesToSpawn;
    public int hitsToBreak;

    public GameObject projectilePrefab;
    public GameObject respawnPoint;

    int hitCount = 0;
    float seconds = 0;

    private State state = State.First;
    public bool battleTrigger = false;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    public override void Update()
    {
        seconds += Time.deltaTime;
        if (battleTrigger)
        {
            switch (state)
            {
                case State.First:
                    if (seconds >= 5.0f)
                    {
                        LaunchProjectile();
                        seconds = 0;
                    }
                    break;
                case State.Second:
                    if (seconds >= 3.0f)
                    {
                        LaunchProjectile();
                        seconds = 0;
                    }
                    break;
                case State.Third:
                    if (seconds >= 1.5f)
                    {
                        LaunchProjectile();
                        seconds = 0;
                    }
                    break;
            }
        }
        
    }

    private void LaunchProjectile()
    {
        Vector3 direction = Player.player.transform.position - transform.position;
        direction.Normalize();
        GameObject projectile = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);
        projectile.transform.parent = this.transform;
        EnemyProjectile ep = projectile.GetComponent<EnemyProjectile>();
        ep.Launch(this, direction, 300);
    }

    protected override void OnCollisionStay2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();

        if (player != null && !player.isInvincible)
        {
            CharacterSheet.charSheet.ChangeHealth(-(int)(CharacterSheet.charSheet.baseStats.GetStats("currentHP") * 0.5f));
        }
    }

    public void CrystalHit()
    {
        if (CharacterSheet.charSheet.currentWeapon.weaponID == 2)
        {
            hitCount++;
            if (hitCount == hitsToBreak)
            {
                Die();
            }
            Vector2 spawnPoint = new Vector2(Random.Range(this.transform.position.x - 3, this.transform.position.x + 4), Random.Range(this.transform.position.y - 3, this.transform.position.y + 4));
            int numberToSpawn = Random.Range(1, 4);
            for (int i = 0; i < numberToSpawn; i++)
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint, Quaternion.identity, this.transform);
            SwitchState();
        }
    }

    private void SwitchState()
    {
        switch (state)
        {
            case State.First:
                state = State.Second;
                break;
            case State.Second:
                state = State.Third;
                break;
        }
    }
}
