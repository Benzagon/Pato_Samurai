using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemyMoveSpeed;


    private bool moveLeft = true;

    Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
        
	void Update ()
    {
        if (moveLeft == true)
        {
            rb2d.velocity = new Vector2(-enemyMoveSpeed, rb2d.velocity.y);
            transform.localScale = new Vector3(1.5f, 4.5f, 4.5f);
        }

        else if (moveLeft == false)
        {
            rb2d.velocity = new Vector2(enemyMoveSpeed, rb2d.velocity.y);
            transform.localScale = new Vector3(-1.5f, 4.5f, 4.5f);
        }
    }
       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall" || collision.collider.tag ==  "Enemy" || collision.collider.tag == "Platform")
        {
            moveLeft = !moveLeft;
        }
    }
}
