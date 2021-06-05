using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]

public class EnemyWalker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <=0)
        {
            speed = 3.0f;
        }
        if (health<=0)
        {
            health = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Death") && !anim.GetBool("Squish"))
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Barrier")
        {
            sr.flipX = !sr.flipX;
        }
    }

    public void IsDead()
    {
        health--;
        if (health <= 0)
        {
            anim.SetBool("Death", true);
            rb.velocity = Vector2.zero;
        }
    }

    public void IsSquished()
    {
        anim.SetBool("Squish", true);
        rb.velocity = Vector2.zero;
    }

    public void FinishDeath()
    {
        Destroy(gameObject.transform.parent.gameObject);
        GameManager.instance.lives++;

    }
}
