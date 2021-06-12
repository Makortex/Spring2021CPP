using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES
    }

    public CollectibleType currentCollectible;
    public AudioClip pickupAudioClip;

    private void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Collider2D>();
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement curMovementScript = collision.GetComponent<PlayerMovement>();
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    //PlayerMovement pmScript = collision.gameObject.GetComponent<PlayerMovement>();
                    GameManager.instance.score++;
                    break;
                case CollectibleType.POWERUP:
                    break;
                case CollectibleType.LIVES:
                    //pmScript = collision.gameObject.GetComponent<PlayerMovement>();
                    GameManager.instance.lives++;
                    break;
            }

            if (pickupAudioClip && curMovementScript)
                curMovementScript.CollectibleSound(pickupAudioClip);

            Destroy(gameObject);
        }
}
}
