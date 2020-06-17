﻿using System;
using UnityEngine;

/// <summary>
/// This class handle Enemy behaviour. It make them walk back & forth as long as they aren't fixed, and then just idle
/// without being able to interact with the player anymore once fixed.
/// </summary>
public class Enemy : MonoBehaviour
{
	// ====== ENEMY MOVEMENT ========
	public enum EnemyType {SEEKER, ROAMER}
	public float speed;
	public float timeToChange;
	public bool horizontal;
	public EnemyType type;
	public int xpAmount;

	public GameObject smokeParticleEffect;
	public ParticleSystem fixedParticleEffect;

	public AudioClip hitSound;
	public AudioClip fixedSound;
	
	Rigidbody2D rigidbody2d;
	float remainingTimeToChange;
	Vector2 direction = Vector2.right;
	
	// ===== ANIMATION ========
	Animator animator;
	
	// ================= SOUNDS =======================
	AudioSource audioSource;
	
	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		remainingTimeToChange = timeToChange;

		direction = horizontal ? Vector2.right : Vector2.down;

		animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		if (type == EnemyType.ROAMER)
		{
			remainingTimeToChange -= Time.deltaTime;

			if (remainingTimeToChange <= 0)
			{
				remainingTimeToChange += timeToChange;
				direction *= -1;
			}

			animator.SetFloat("ForwardX", direction.x);
			animator.SetFloat("ForwardY", direction.y);
		}
	}

	void FixedUpdate()
	{
		rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		
		RubyController controller = other.collider.GetComponent<RubyController>();
		
		if(controller != null)
			controller.ChangeHealth(-1);
	}

	public void Fix()
	{
		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		//we don't want that enemy to react to the player or bullet anymore, remove its reigidbody from the simulation
		rigidbody2d.simulated = false;

		
		Player.player.baseStats.AddXP(xpAmount);
		Debug.Log("xp: " + Player.player.baseStats.GetStats("xp").ToString());
		
		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		audioSource.PlayOneShot(fixedSound);
		Destroy(this.gameObject);
	}
}
