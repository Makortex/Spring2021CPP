using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer marioSprite;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool Attack;
    public bool JAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        marioSprite = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please assign a ground check object");
        }

    }
    
    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        if (marioSprite.flipX && horizontalInput > 0 || !marioSprite.flipX && horizontalInput < 0)
            marioSprite.flipX = !marioSprite.flipX;

        float verticalInput = Input.GetAxisRaw("Vertical");

        

        void FloorAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack = true;
            }
        }

        void FloorAttack()
        {
            if (Attack)
            {
                anim.SetTrigger("Attack");
            }
        }

        void JumpAttackInput()
        {
            if (Input.GetKey(KeyCode.Space) && Input.GetKey("up"))
            {
                JAttack = true;
            }
            
        }
        
        void JumpAttack()
        {
            if (JAttack)
            {
                anim.SetTrigger("JAttack");
            }
        }
        
        void ResetValues()
        {
            Attack = false;
            JAttack = false;
        }



        FloorAttackInput();
        FloorAttack();
        JumpAttackInput();
        JumpAttack();
        ResetValues();
    }
}
