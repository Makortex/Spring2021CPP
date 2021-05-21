using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyTurret : MonoBehaviour
{
    public Transform SpawnPointR;
    public Transform SpawnPointL;

    public Projectile projectilePrefab;

    public float projectileForce;

    public float projectileFireRate;
    public bool isInRange;

    float timeSinceLastFire = 0.0f;
    public float health;

    public SpriteRenderer TurretSprite;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (projectileForce <=0)
        {
            projectileForce = 7.0f;
        }

        if (projectileFireRate <= 0)
        {
            projectileFireRate = 2.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeSinceLastFire + projectileFireRate && isInRange)
        {
            anim.SetBool("Fire", true);
            timeSinceLastFire = Time.time;
        }

    }
    public void Fire()
    {
        if (TurretSprite.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, SpawnPointR.position, SpawnPointR.rotation);
            projectileInstance.speed = projectileForce;
        }
        if (!TurretSprite.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, SpawnPointL.position, SpawnPointL.rotation);
            projectileInstance.speed = -projectileForce;
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if(health<=0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void LRange()
    {
        if (TurretSprite.flipX)
        {
            TurretSprite.flipX = !TurretSprite.flipX;
            anim.SetBool("Fire", true);
        }
    }

    public void RRange()
    {
        if (!TurretSprite.flipX)
        {
            TurretSprite.flipX = !TurretSprite.flipX;
            anim.SetBool("Fire", true);
        }
    }

    public void IsInRange()
    {
        isInRange = true;
    }
    
    public void OOR()
    {
        isInRange = false;
        anim.SetBool("Fire", false);
    }
}
