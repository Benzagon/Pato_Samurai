using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour {

    [SerializeField] private LayerMask groundLayerMask;

    public float slimeMoveSpeed;
    public float slimeJumpHeight;
    private float slimeScaleX;

    private float jumpCooldown;
    public float cooldownSeconds;
    public int health;
    public int numOfJumps;

    private int slimeJumpCount = 0;

    private Animator animator;

    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    Transform trans;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        trans = GetComponent<Transform>();

        slimeMoveSpeed = -slimeMoveSpeed;
        slimeScaleX = trans.localScale.x;
    }
		
	void Update () {      
        
        if (isGrounded() && jumpCooldown <= Time.time)
        {
            if (slimeJumpCount >= numOfJumps)
            {
                turnAround();
                slimeJumpCount = 0;
            }

            rb2d.velocity = Vector2.up * slimeJumpHeight;
            rb2d.velocity = new Vector2(slimeMoveSpeed, rb2d.velocity.y);
            transform.localScale = new Vector3(slimeScaleX, 4f, 4.5f);

            animator.SetBool("jumping", true);

            jumpCooldown = Time.time + cooldownSeconds;

            slimeJumpCount += 1;
        }
        
        else if(isGrounded() && jumpCooldown >= Time.time)
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            animator.SetBool("jumping", false);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, groundLayerMask);
               
        return raycastHit.collider != null;
    }
        
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void turnAround()
    {
        slimeMoveSpeed = -slimeMoveSpeed;
        slimeScaleX = -slimeScaleX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Enemy")
        {
            turnAround();
        }
    }
}

