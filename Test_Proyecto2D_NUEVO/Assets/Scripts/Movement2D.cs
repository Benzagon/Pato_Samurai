using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour {

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask slimeLayerMask;

    public float moveSpeed;
    public float jumpHeight;
    public int health;

    bool cp1IsActive = false;
    public GameObject CP1;

    bool cp2IsActive = false;
    public GameObject CP2;

    Vector3 startPos;

    private Animator animator;
    public Animator CP1Animator;
    public Animator CP2Animator;
    
    public bool isDashing = false;
    private bool isFacingRight = true;
    private float currentDashTimer;

    public float dashCooldownTimer;
    public float startDashTimer;
    public float dashCooldown;
    private float dashDirection;
    public float dashForce;

    public Slider dashCooldownSlider;
    public Image dashCooldownBorder;
    public Image dashCooldownBackground;  

    Quaternion defaultRot;
        
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
        defaultRot = transform.rotation;
        startPos = transform.position;

        dashCooldownSlider.value = 0f;
               
    }   

    void Update() {


        if (transform.rotation != defaultRot)
            transform.rotation = defaultRot;

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded() == true)
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

        if (!isDashing)
        {
            dashCooldownTimer -= Time.deltaTime;
            rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

            dashCooldownSlider.value = dashCooldownTimer;

            if(dashCooldownSlider.value <= 0.05)
            {
                dashCooldownBorder.enabled = false;
                dashCooldownBackground.enabled = false;
            }

            else
            {
                dashCooldownBorder.enabled = true;
                dashCooldownBackground.enabled = true;
            }
        }

       if(isGrounded() == true)
            animator.SetBool("isGrounded", true);

       else
            animator.SetBool("isGrounded", false);

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

        animator.SetTrigger("dash");

        if(isFacingRight == true)
            dashDirection = moveSpeed;

        if (isFacingRight == false)
            dashDirection = -moveSpeed;
    }
       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Respawn" || collision.collider.tag == "Enemy")
        {            
            health--;

            if (health <= 0)
            {
                //Time.timeScale = .5f;
                SceneManager.LoadScene("DeathScreen");
                                
            }
            else
            {
                transform.position = startPos;
                animator.SetBool("walking", false);
            }
        }

        else if (collision.collider.tag == "EnemyHead")
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CP1 && cp1IsActive == false)
        {
            startPos = transform.position;
            CP1Animator.SetTrigger("getCP");
            health = 3;
            cp1IsActive = true;
        }

        if (CP2 && cp2IsActive == false)
        {
            startPos = transform.position;
            CP2Animator.SetTrigger("getCP");
            health = 3;
            cp2IsActive = true;
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, groundLayerMask);

        return raycastHit.collider != null;
    }

    //private bool jumpOnEnemy()
    //{
    //    float extraHeightText = .1f;
    //    RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, slimeLayerMask);

    //    return raycastHit.collider != null;
    //}
}
