using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    Transform player;
    Transform A;
    Transform B;
    Rigidbody2D rb;
    public float attackRange = 10f;
    public bool isFlipped = false;
    // Start is called before the first frame update
    public void Dash()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        A = GameObject.FindGameObjectWithTag("A").transform;
        B = GameObject.FindGameObjectWithTag("B").transform;
        rb = GetComponent<Rigidbody2D>();
        if (transform.position.x > player.position.x)
        {
            isFlipped = true;
        }
        else if (transform.position.x < player.position.x)
        {
            isFlipped = false;
        }
        if (isFlipped)
        {
            Console.WriteLine(Vector2.Distance(player.position, A.position));
            if (Vector2.Distance(player.position, A.position) > attackRange)
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, player.position, attackRange);
                rb.MovePosition(newPos);
            }
            else
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, A.position, attackRange );
                rb.MovePosition(newPos);
            }
        }
        else
        {
            Console.WriteLine(Vector2.Distance(player.position, B.position));
            if (Vector2.Distance(player.position, B.position) > attackRange)
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, player.position, attackRange);
                rb.MovePosition(newPos);
            }
            else
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, B.position, attackRange );
                rb.MovePosition(newPos);
            }
        }
    }
}
