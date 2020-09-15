using System;
using UnityEngine;

public class RoamerEnemy : Enemy
{
	// ====== ENEMY MOVEMENT ========
	
	public float speed;
	public float timeToChange;
	public bool horizontal;
	
	float remainingTimeToChange;
	Vector2 direction = Vector2.right;
	
	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		remainingTimeToChange = timeToChange;

		direction = horizontal ? Vector2.right : Vector2.down;

		animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();
	}
	
	public override void Update()
	{
		base.Update();
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

	

	

}
