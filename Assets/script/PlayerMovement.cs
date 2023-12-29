using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Horizontal;
    private float Speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    


    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public HealthBar healthBar;

    public GameObject gameOverPanel;

    
    void start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
       
     Horizontal = Input.GetAxisRaw("Horizontal");

      if(IsGrounded() && !Input.GetButton("Jump"))
      {
        doubleJump = false;
      }

     if(Input.GetButtonDown("Jump"))
     {
        if (IsGrounded() || doubleJump)
        {
        rb.velocity =new Vector2(rb.velocity.x,jumpingPower);
        doubleJump = !doubleJump;
        }
     }
      
    
     if (Input.GetButtonUp("Jump")&& rb.velocity.y > 0f)
     {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
     }
     Flip();

    }
    private void FixedUpdate()
    {
        rb.velocity =new Vector2(Horizontal * Speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer); 
    }
    private void Flip()
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal>0f )
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            healthBar.Damage(0.005f);
            
            gameOverPanel.SetActive(true);
            
        }
        
        
    }
   
    
}
