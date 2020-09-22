using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wyrm : Enemy
{
    public enum States { Hover, FireAttack, ClawAttack, Charge}

    public Transform target;
    public GameObject projectilePrefab;
    public int burstAmount;

    private States currentState = States.Hover;
    private States lastState;

    private float fireTimer = 10;
    private float clawTimer = 5;
    private bool isFlipped = false;
    private int shotCounter = 0;
    private Vector3 direction;

    protected override void Awake()
    {
        base.Awake(); 
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Update()
    {
        base.Update();

        lastState = currentState;
        float distance = Vector2.Distance(this.transform.position, target.transform.position);

        fireTimer += Time.deltaTime;
        clawTimer += Time.deltaTime;

        switch (currentState)
        {
            case States.Hover:
                if (distance > 6)
                {
                    SwitchState(States.Charge);
                }
                else if (distance < 4 && distance > 2 && fireTimer > 10)
                {
                    SwitchState(States.FireAttack);
                }
                else if (distance < 2 && clawTimer > 5)
                {
                    SwitchState(States.ClawAttack);
                }
                break;
            case States.FireAttack:
                fireTimer = 0;
                InvokeRepeating(nameof(LaunchProjectile), 0f, 1f);
                SwitchState(States.Hover);
                break;
            case States.ClawAttack:
                clawTimer = 0;
                animator.SetTrigger(currentState.ToString());
                SwitchState(States.Hover);
                animator.ResetTrigger(lastState.ToString());
                break;
            case States.Charge:
                float step = speed * Time.deltaTime;
                LookAtPlayer();
                animator.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                if (distance < 4)
                    SwitchState(States.Hover);
                break;
        }
    }

    private void SwitchState(States state)
    {
        animator.SetBool("isRunning", false);
        lastState = currentState;
        currentState = state;
        Debug.Log(state.ToString());
    }

    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > target.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < target.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void LaunchProjectile()
    {
            direction = Player.player.transform.position - transform.position;
            direction.Normalize();
            GameObject projectile = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);
            projectile.transform.parent = this.transform;
            EnemyProjectile ep = projectile.GetComponent<EnemyProjectile>();
            ep.Launch(this, direction, 300);
        shotCounter++;
        if (shotCounter == burstAmount)
        {
            CancelInvoke();
        }
    }

}
