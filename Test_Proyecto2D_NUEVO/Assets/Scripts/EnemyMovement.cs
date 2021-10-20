﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemyMoveSpeed;

    public int health;
    private float waitTime;

    public ParticleSystem PSDie;

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
            transform.localScale = new Vector3(4f, 4f, 4.5f);
        }

        else if (moveLeft == false)
        {
            rb2d.velocity = new Vector2(enemyMoveSpeed, rb2d.velocity.y);
            transform.localScale = new Vector3(-4f, 4f, 4.5f);
        }

        if (health <= 0)
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            if (waitTime <= 0)
            {
                Destroy(gameObject);
                health--;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        waitTime = 0.5f;
        health -= damage;
    }

    private void OnDestroy()
    {
        Instantiate(PSDie, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall" || collision.collider.tag ==  "Enemy" || collision.collider.tag == "Platform" || collision.collider.tag == "Respawn")
        {
            moveLeft = !moveLeft;
        }
    }
}
