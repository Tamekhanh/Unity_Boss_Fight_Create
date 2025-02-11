using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float attackRange = 5f;
    public float speed = 5.0f;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    private float SlashRate = 3f;
    private float SlashNext;
    private float DashRate = 10f;
    private float DashNext;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("shoot");
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2  newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        dashattack(animator);
        basicattack(animator);
    }

    public void dashattack (Animator animator)
    {
        if (Time.time > DashNext)
        {
            DashNext = Time.time + DashRate;
            animator.SetTrigger("dash");
        }
    }

    public void basicattack (Animator animator)
    {
        if (Vector2.Distance(player.position, rb.position) <= attackRange && Time.time > SlashNext)
        {
            SlashNext = Time.time + SlashRate;
            animator.SetTrigger("attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("shoot");
        animator.ResetTrigger("attack");
        animator.ResetTrigger("dash");
    }
}
