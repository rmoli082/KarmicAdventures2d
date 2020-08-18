using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour {
	
	public float speed = 20.0f;
	public float aggroDistOrig = 1f;
	public Transform target;
	private float aggroDist;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () 
	{
		// if no target specified, assume the player
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}

		aggroDist = aggroDistOrig;
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
			return;

		//get the distance between the chaser and the target
		float distance = Vector2.Distance(transform.position,target.position);
		float step = speed * Time.deltaTime;

		//so long as the chaser is within the minimum distance, move towards it at rate speed.
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

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
