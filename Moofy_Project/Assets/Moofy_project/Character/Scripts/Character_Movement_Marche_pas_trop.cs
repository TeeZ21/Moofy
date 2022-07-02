using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_Marche_pas_trop : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isNotJumping;

    public Transform jumpCheckLeft;
    public Transform jumpCheckRight;


    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;


   
    void FixedUpdate()
    {
        isNotJumping = Physics2D.OverlapArea(jumpCheckLeft.position, jumpCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Escape) && isNotJumping )
        {
            isJumping = true;
        }


        Moveplayer(horizontalMovement);


    }

    void Moveplayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}


