using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    
    public bool isGrounded = false;
    private Animator animator;

    Rigidbody2D rb2d;
    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update() {
       
        if (Input.GetButtonDown("Jump") && isGrounded == true)
            Jump();

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            animator.SetBool("walking", true);

            //if (rb2d.velocity.y == 0.0f)
                transform.localScale = new Vector3(3.75f, 3.75f, 3.75f);

        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                animator.SetBool("walking", true);

               // if(rb2d.velocity.y == 0.0f)
                    transform.localScale = new Vector3(-3.75f, 3.75f, 3.75f);
            }
            else
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
                animator.SetBool("walking", false);
            }
        }

        
        
        
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up * jumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Respawn"|| collision.collider.tag == "Enemy")
        {
            transform.position = new Vector3(-24.8f, 2.06f, 0f);
            animator.SetBool("walking", false);
        }

        if (collision.collider.tag == "EnemyHead")
            Jump();
             
    }
}
