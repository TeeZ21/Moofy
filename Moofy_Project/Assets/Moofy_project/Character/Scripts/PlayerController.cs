using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private TrailRenderer tr;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool isFacingRight = true;
    
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        jumpForce = 40f;
        isJumping = false;
        canDash = true;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

       moveHorizontal = Input.GetAxisRaw("Horizontal");

       if ( Input.GetKeyDown(KeyCode.LeftShift) && canDash)
       {
           StartCoroutine(Dash());
       }

       moveVertical = Input.GetAxisRaw("Vertical");

       Flip();

       if(Input.GetKeyDown(KeyCode.L))
       {
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
       }

    }

    private void Flip()
    {

        if(isFacingRight && moveHorizontal < 0.1f || !isFacingRight && moveHorizontal > 0.1f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate() 
    { 
          if (isDashing)
        {
            return;
        }

        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        
        if(!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision) 
    {
        isJumping = true;    
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb2D.gravityScale;
        rb2D.gravityScale = 0f;
        rb2D.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
