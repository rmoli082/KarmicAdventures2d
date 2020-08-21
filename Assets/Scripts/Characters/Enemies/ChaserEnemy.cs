using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class ChaserEnemy : Enemy 
{
	
	public float speed = 20.0f;
	public float aggroDistOrig = 1f;
	public Transform target;
	private float aggroDist;

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
		

		aggroDist = aggroDistOrig;
		originalPosition = transform.position;
	}
	
	void Update () 
	{
		if (target == null)
			return;

		float distance = Vector2.Distance(transform.position,target.position);
		float step = speed * Time.deltaTime;

		if(distance < aggroDist)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
			aggroDist = aggroDistOrig * 2;
		} 
		else if (distance >= aggroDistOrig * 2)
		{
			transform.position = Vector2.MoveTowards(transform.position, originalPosition, step);
		}
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
