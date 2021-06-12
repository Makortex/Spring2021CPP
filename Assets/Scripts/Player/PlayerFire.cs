using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer marioSprite;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    //AudioSource fireAudioSource;
    //public AudioClip fireSFX;
    //public AudioMixerGroup audioMixer;

    //public bool Attack;

    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //fireAudioSource = GetComponent<AudioSource>();


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
        //if (!fireAudioSource)
        //{
        //    fireAudioSource = gameObject.AddComponent<AudioSource>();
        //    fireAudioSource.clip = fireSFX;
        //    fireAudioSource.outputAudioMixerGroup = audioMixer;
        //    fireAudioSource.loop = false;
        //}

        //fireAudioSource.Play();

        if (marioSprite.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = -projectileSpeed;
            
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }

    }


}

        