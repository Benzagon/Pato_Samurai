using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask slimeLayerMask;

    public float moveSpeed;
    public float jumpHeight;

    Vector3 startPos;

    private Animator animator;

    public bool isDashing = false;
    private bool isFacingRight = true;
    private float currentDashTimer;

    public float dashCooldownTimer;
    public float startDashTimer;
    public float dashCooldown;
    private float dashDirection;
    public float dashForce;

    Quaternion defaultRot;
        
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        defaultRot = transform.rotation;
        startPos = transform.position;
    }   

    void Update() {


        if (transform.rotation != defaultRot)
            transform.rotation = defaultRot;

        if (Input.GetButtonDown("Jump") && isGrounded() == true)
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift) && moveSpeed != 0 && dashCooldownTimer <= 0)
            Dash();

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

            animator.SetBool("walking", true);

           if (rb2d.velocity.x > 0.0f)
                transform.localScale = new Vector3(3.75f, 3.75f, 3.75f);

            isFacingRight = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                animator.SetBool("walking", true);

                if(rb2d.velocity.x < 0.0f)
                    transform.localScale = new Vector3(-3.75f, 3.75f, 3.75f);

                isFacingRight = false;
            }
            else
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
                animator.SetBool("walking", false);
            }
        }

        if (isDashing)
        {
            rb2d.velocity = transform.right * dashDirection * dashForce;

            currentDashTimer -= Time.deltaTime;

            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            
            if (currentDashTimer <= 0)
            {
                isDashing = false;
            }
        }

        if(!isDashing)
        {
            dashCooldownTimer -= Time.deltaTime;
            rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }

        if(jumpOnEnemy())
        {
            Jump();
        }
            
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up * jumpHeight;
    }

    void Dash()
    {
         isDashing = true;
         currentDashTimer = startDashTimer;
         dashCooldownTimer = dashCooldown;
         rb2d.velocity = Vector2.zero;

        if(isFacingRight == true)
            dashDirection = moveSpeed;

        if (isFacingRight == false)
            dashDirection = -moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.collider.tag == "Respawn"|| collision.collider.tag == "Enemy")
        //{
        //    //Time.timeScale = .5f;
        //    transform.position = startPos;
        //    animator.SetBool("walking", false);
        //}

        //if (collision.collider.tag == "EnemyHead")
        //    Jump();
             
    }

    private bool isGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, groundLayerMask);

        return raycastHit.collider != null;
    }

    private bool jumpOnEnemy()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, slimeLayerMask);

        return raycastHit.collider != null;
    }
}
