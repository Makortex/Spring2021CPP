using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer marioSprite;
    AudioSource pickupAudioSource;
    AudioSource jumpAudioSource;
    

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool Attack;
    public bool JAttack;

    public AudioClip jumpSFX;
    public AudioMixerGroup audioMixer;

    //public int score = 0;
    //public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        marioSprite = GetComponent<SpriteRenderer>();
        pickupAudioSource = GetComponent<AudioSource>();


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


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);

            if (!jumpAudioSource)
            {
                jumpAudioSource = gameObject.AddComponent<AudioSource>();
                jumpAudioSource.clip = jumpSFX;
                jumpAudioSource.outputAudioMixerGroup = audioMixer;
                jumpAudioSource.loop = false;
            }

            jumpAudioSource.Play();
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

    //public void StartJumpForceChange()
    //{
    //    StartCoroutine(JumpForceChange());
    //}

    //ienumerator jumpforcechange()
    //{
    //    jumpforce = 600;
    //    yield return new waitforseconds(10.0f);
    //    jumpforce = 300;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squish")
        {
            if (!isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 100);
            }
        }

        if (collision.gameObject.tag == "LeftRange")
        {
            collision.gameObject.GetComponentInParent<EnemyTurret>().LRange();
            collision.gameObject.GetComponentInParent<EnemyTurret>().IsInRange();
        }
        if (collision.gameObject.tag == "RightRange")
        {
            collision.gameObject.GetComponentInParent<EnemyTurret>().RRange();
            collision.gameObject.GetComponentInParent<EnemyTurret>().IsInRange();
        }
        if (collision.gameObject.tag == "OORR")
        {
            collision.gameObject.GetComponentInParent<EnemyTurret>().OOR();
        }
        if (collision.gameObject.tag == "OORL")
        {
            collision.gameObject.GetComponentInParent<EnemyTurret>().OOR();
        }
    }
    public void CollectibleSound(AudioClip pickupAudio)
    {
        pickupAudioSource.clip = pickupAudio;
        pickupAudioSource.Play();
    }
}

