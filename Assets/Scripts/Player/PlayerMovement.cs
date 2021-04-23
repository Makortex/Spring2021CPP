using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer Player;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundedLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    // Start is called before the first frame update
    // Run GetComponent in the Start(), never Update().
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GetComponent<SpriteRenderer>();

        if (!rb)
        {
            Debug.Log("Rigidbody2D does not exist");
        }
        if (!anim)
        {
            Debug.Log("Animation does not exist");
        }
        if (!Player)
        {
            Debug.Log("Player does not exist");
        }

        if (speed <= 0)
        {
            speed = 5.0f;
        }
        if (jumpForce <= 0)
        {
            jumpForce = 320;
        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundedLayer);

        transform.Translate(new Vector2(horizontalInput * Time.deltaTime * 4, 320));
        Debug.Log(horizontalInput);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
            rb.velocity = Vector2.zero;
        }

        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        if (Player.flipX && horizontalInput > 0 || !Player.flipX && horizontalInput < 0)
            Player.flipX = !Player.flipX;

    }
}