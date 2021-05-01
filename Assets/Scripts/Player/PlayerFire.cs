using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer marioSprite;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;
    

    //public bool Attack;

    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }
        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
        {
            Debug.Log("Unity inspector values not set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FireProjectile()
    {
        
        if (marioSprite.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = projectileSpeed;
            //GetComponent<Rigidbody2D>().AddForce(spawnPointLeft.rotation * Vector3.left * projectileSpeed);
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }
        
    }


}

        