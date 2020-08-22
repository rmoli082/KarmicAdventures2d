using UnityEngine;
using System.Collections;

public class ChaserEnemy : Enemy 
{
	
	public float speed = 20.0f;
	public Transform target;

	private Vector3 originalPosition;

	void Start () 
	{
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
		
			rigidbody2d = GetComponent<Rigidbody2D>();

			animator = GetComponent<Animator>();

			audioSource = GetComponent<AudioSource>();

		if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Stealth"))
		{
			aggroDist = aggroDistance * (1 - (CharacterSheet.charSheet.selectedSkills["Stealth"] / 200f));
		} 
		else
		{
			aggroDist = aggroDistance;
		}



		originalPosition = transform.position;
	}
	
	void Update () 
	{
		if (target == null)
			return;

		float distance = Vector2.Distance(transform.position, target.position);
		float step = speed * Time.deltaTime;

		if (distance < aggroDist)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
			aggroDist = aggroDistance * 2;
		}
		else if (distance >= aggroDistance * 2)
		{
			transform.position = Vector2.MoveTowards(transform.position, originalPosition, step);
		}
	}


}
