using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<Collider2D>();
        //if (other.gameObject.CompareTag("Player"))
        //{
            Destroy(gameObject);
        //}
    }
}
