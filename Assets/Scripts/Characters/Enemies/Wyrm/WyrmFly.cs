using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmFly : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3.0f;

    Transform player;
    Rigidbody2D rb;

    Wyrm wyrm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        wyrm = animator.GetComponent<Wyrm>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wyrm.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        rb.gameObject.transform.position = Vector2.MoveTowards(rb.transform.position, target, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("FireAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("FireAttack");
    }

}

