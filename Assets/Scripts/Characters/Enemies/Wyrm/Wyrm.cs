﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wyrm : MonoBehaviour
{
	public int attack;
	public int defense;
	public int magic;
	public int xpAmount;
	public float aggroDistance;
	public int numberOfDice;
	public int damageDice;

	public Stats baseStats;

	public Transform player;
	public bool isFlipped;

	private void Awake()
	{
		baseStats = new Stats();

		baseStats.UpdateStats("attack", attack);
		baseStats.UpdateStats("defense", defense);
		baseStats.UpdateStats("magic", magic);
		//baseStats.UpdateStats("level", Random.Range(1, CharacterSheet.charSheet.baseStats.GetStats("level") + 3));
		baseStats.UpdateStats("hp", 2 * (baseStats.GetStats("defense") + baseStats.GetStats("level")));
		baseStats.UpdateStats("mp", 2 * (baseStats.GetStats("magic") + baseStats.GetStats("level")));
		baseStats.UpdateStats("currentHP", baseStats.GetStats("hp"));
		baseStats.UpdateStats("currentMP", baseStats.GetStats("mp"));
	}

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= 4.0f)
        {
			GetComponent<Animator>().SetBool("isRunning", true);
			float speed = 3.0f;
			Vector2 target = new Vector2(player.position.x, transform.position.y);
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
		else
        {
			GetComponent<Animator>().SetBool("isRunning", false);
			GetComponent<Animator>().SetTrigger("FireAttack");
		}
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	public int CalculateFireDamage()
    {
		int damageAmount = 0;

		for (int i = 0; i < numberOfDice; i++)
        {
			damageAmount += Random.Range(1, damageDice + 1);
        }

		damageAmount += Mathf.RoundToInt((baseStats.GetStats("attack") - 10) / 2f);
		damageAmount += Mathf.RoundToInt(baseStats.GetStats("magic") / 2 * 0.3f);

		return damageAmount;
    }
}