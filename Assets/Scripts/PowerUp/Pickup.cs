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

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //GetComponent<Collider2D>();
    //    //if (collision.gameObject.tag == "Player")
    //    //{
    //    //    Destroy(gameObject);
    //    //    switch (currentCollectible)
    //    //    {
    //    //        case CollectibleType.COLLECTIBLE:
    //    //            PlayerMovement pmScript = collision.gameObject.GetComponent<PlayerMovement>();
    //    //            pmScript.score++;
    //    //            break;
    //    //        case CollectibleType.POWERUP:
    //    //            break;
    //    //        case CollectibleType.LIVES:
    //    //            pmScript = collision.gameObject.GetComponent<PlayerMovement>();
    //    //            pmScript.lives++;
    //    //            break;
    //    //    }

    //        Destroy(gameObject);
    //    }
    //}
}
