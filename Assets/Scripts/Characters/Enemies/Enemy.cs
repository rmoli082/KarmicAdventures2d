using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { CHASER, ROAMER, RANGED }

    public EnemyType type;
	public int attack;
	public int defense;
	public int magic;
	public int xpAmount;
	public float aggroDistance;

    public ParticleSystem fixedParticleEffect;

    public AudioClip hitSound;

	protected Rigidbody2D rigidbody2d;
	protected Animator animator;
	protected AudioSource audioSource;
	protected Stats baseStats;
	protected float aggroDist;

    private void Awake()
    {
		baseStats = new Stats();

		baseStats.UpdateStats("attack", attack);
		baseStats.UpdateStats("defense", defense);
		baseStats.UpdateStats("magic", magic);
		baseStats.UpdateStats("level", Random.Range(0, CharacterSheet.charSheet.baseStats.GetStats("level") + 3));
		baseStats.UpdateStats("hp", 2 * (baseStats.GetStats("defense") + baseStats.GetStats("level")));
		baseStats.UpdateStats("mp", 2 * (baseStats.GetStats("magic") + baseStats.GetStats("level")));
		baseStats.UpdateStats("currentHP", baseStats.GetStats("hp"));
		baseStats.UpdateStats("currentMP", baseStats.GetStats("mp"));
    }


    void OnCollisionStay2D(Collision2D other)
	{

		Player player = other.collider.GetComponent<Player>();

		if (player != null)
			CharacterSheet.charSheet.ChangeHealth(-1);
	}


	public void Die()
	{
		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		rigidbody2d.simulated = false;

		CharacterSheet.charSheet.baseStats.UpdateStats("xp", xpAmount);

		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		Destroy(this.gameObject);
		GameEvents.OnKillSuccessful(gameObject.tag);
	}
}
