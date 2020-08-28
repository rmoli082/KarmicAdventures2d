using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmAttack : MonoBehaviour
{
	public Vector3 fireAttackOffset;

	public Vector3 clawAttackOffset;
	public Vector2 fireAttackSize;
	public float clawAttackRange;
	public LayerMask attackMask;

	private int fireAttackDamage;
	private int clawAttackDamage;

	public void FireAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * fireAttackOffset.x;
		pos += transform.up * fireAttackOffset.y;

		Vector3 posB = transform.position;
		posB += transform.right * fireAttackOffset.x;
		posB += transform.up * fireAttackOffset.y;


		Collider2D colInfo = Physics2D.OverlapCapsule(pos, fireAttackSize, CapsuleDirection2D.Horizontal, 0, attackMask);
		if (colInfo != null)
		{
			fireAttackDamage = GetComponent<Wyrm>().CalculateFireDamage();
			CharacterSheet.charSheet.ChangeHealth(-fireAttackDamage);
		}
	}

	public void ClawAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * clawAttackOffset.x;
		pos += transform.up * clawAttackOffset.y;

		//Collider2D colInfo = Physics2D.OverlapCapsule(pos, clawAttackRange, CapsuleDirection2D.Horizontal, attackMask);
		//if (colInfo != null)
		//{
		//	CharacterSheet.charSheet.ChangeHealth(clawAttackDamage);
		//}
	}

    

}
