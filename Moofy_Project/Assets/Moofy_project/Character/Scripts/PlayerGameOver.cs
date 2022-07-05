using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Obstacles"))
        {
            Die();
        }
    }

    private void Die() 
    {
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Die");
    }
}
