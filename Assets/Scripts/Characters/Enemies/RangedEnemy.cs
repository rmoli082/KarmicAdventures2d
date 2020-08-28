using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
	public GameObject projectilePrefab;
	public Transform target;

	public int speed;
	public float shotTimer = 1.5f;

	void Start()
	{
		if (target == null)
		{

			if (GameObject.FindWithTag("Player") != null)
			{
				target = GameObject.FindWithTag("Player").GetComponent<Transform>();
			}
		}

		rigidbody2d = GetComponent<Rigidbody2D>();

		animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();

		if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Stealth"))
		{
			aggroDist = aggroDistance * (1 - (CharacterSheet.charSheet.selectedSkills["Stealth"] * 0.03f));
		}
		else
		{
			aggroDist = aggroDistance;
		}
	}


	public override void Update()
	{
		base.Update();
		if (target == null)
			return;

		float distance = Vector2.Distance(transform.position, target.position);
		float step = speed * Time.deltaTime;

		Vector2 shotDirection = new Vector2(1, 0);
		shotDirection.Set(target.position.x, target.position.y);
		shotDirection.Normalize();
		if (shotDirection.x < 0.3)
        {
			shotDirection.x = 0f;
        }
		else if (shotDirection.x >= 0.3 && shotDirection.x < 0.8 )
        {
			shotDirection.x = 0.5f;
        }
		else if (shotDirection.x >= 0.8 && shotDirection.x < 1)
        {
			shotDirection.x = 1f;
        }
		if (shotDirection.y < 0.3)
		{
			shotDirection.y = 0f;
		}
		else if (shotDirection.y >= 0.3 && shotDirection.y < 0.8)
		{
			shotDirection.y = 0.5f;
		}
		else if (shotDirection.y >= 0.8 && shotDirection.y < 1)
		{
			shotDirection.y = 1f;
		}
		Debug.Log(shotDirection.ToString());

		if (distance <= aggroDist)
		{
			if (Time.time >= shotTimer)
			{
				GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.6f, Quaternion.identity);
				EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();

				projectile.Launch(this, -shotDirection, 300);
				shotTimer = Time.time + shotTimer;
			}
		}

		if (distance < aggroDist / 2)
        {
			Vector2 newPosition = new Vector2();
			newPosition.x = transform.position.x + Random.Range(-2, 2);
			newPosition.y = transform.position.x + Random.Range(2, 2);
			transform.position = Vector2.MoveTowards(transform.position, newPosition, step);
        }			
		
	}
}
