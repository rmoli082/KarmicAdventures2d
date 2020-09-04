using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightCrystal : Enemy
{
    public GameObject[] enemiesToSpawn;
    public int hitsToBreak;

    int hitCount = 0;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    protected override void OnCollisionStay2D(Collision2D other)
    {
        CharacterSheet.charSheet.ChangeHealth(-(int)(CharacterSheet.charSheet.baseStats.GetStats("currentHP") * 0.5f));
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
        }
    }
}
