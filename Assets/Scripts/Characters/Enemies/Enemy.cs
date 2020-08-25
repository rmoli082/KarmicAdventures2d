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
	public int numberOfDice;
	public int damageDice;


	public Stats baseStats;

	public ParticleSystem fixedParticleEffect;

    public AudioClip hitSound;

	protected Rigidbody2D rigidbody2d;
	protected Animator animator;
	protected AudioSource audioSource;
	protected float aggroDist;
	protected float damageAmount;

	private int attackBoost;

    private void Awake()
    {
		baseStats = new Stats();

		baseStats.UpdateStats("attack", attack);
		baseStats.UpdateStats("defense", defense);
		baseStats.UpdateStats("magic", magic);
		baseStats.UpdateStats("level", Random.Range(1, CharacterSheet.charSheet.baseStats.GetStats("level") + 3));
		baseStats.UpdateStats("hp", 2 * (baseStats.GetStats("defense") + baseStats.GetStats("level")));
		baseStats.UpdateStats("mp", 2 * (baseStats.GetStats("magic") + baseStats.GetStats("level")));
		baseStats.UpdateStats("currentHP", baseStats.GetStats("hp"));
		baseStats.UpdateStats("currentMP", baseStats.GetStats("mp"));
    }


    protected void OnCollisionStay2D(Collision2D other)
	{

		Player player = other.collider.GetComponent<Player>();

		if (player != null && !player.isInvincible)
        {
			CharacterSheet.charSheet.ChangeHealth(CalculateDamage());
		}
			
	}

	public void Damage(float amount)
    {
		baseStats.UpdateStats("currentHP", Mathf.RoundToInt(baseStats.GetStats("currentHP") - amount));
		if (baseStats.GetStats("currentHP") <= 0)
        {
			Die();
        }
    }


	void Die()
	{
		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		rigidbody2d.simulated = false;

		xpAmount -= (CalculateDamage()/2);
		CharacterSheet.charSheet.ChangeXP(xpAmount);
		GameEvents.OnXpAwarded();

		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		Destroy(this.gameObject);
		GameEvents.OnKillSuccessful(gameObject.tag);
	}

	int CalculateDamage()
    {
		damageAmount = 0;
		for (int i = 0; i < numberOfDice; i++)
		{
			damageAmount += Random.Range(1, damageDice);
		}

		if (baseStats.GetStats("attack") > 10)
        {
			attackBoost = baseStats.GetStats("attack") - 10 / 2;
        }

		damageAmount += attackBoost * baseStats.GetStats("level") / 2;

		return Mathf.RoundToInt(-damageAmount);
	}
}
