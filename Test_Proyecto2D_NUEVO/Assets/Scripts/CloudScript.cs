using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    [SerializeField] private LayerMask playerLayerMask;

    private PlatformEffector2D effector;
    private float waitTime;
  
    //public SpriteRenderer spriteRenderer;
    //public Sprite smallCloud;
    //public Sprite fullCloud;

    //BoxCollider2D bc2d;

	void Start () {
        effector = GetComponent<PlatformEffector2D>();

        //bc2d = GetComponent<BoxCollider2D>();
	}
	
	
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.5f;
        }

	    if(Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
                
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            effector.rotationalOffset = 0f;
        }

        //if (isBeingStoodOn())
        //{
        //    spriteRenderer.sprite = smallCloud;
        //}

        //else
        //{
        //    spriteRenderer.sprite = fullCloud;
        //}
    }

    //private bool isBeingStoodOn()
    //{
    //    float extraHeightText = 1f;
    //    RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.up, bc2d.bounds.extents.y + extraHeightText, playerLayerMask);

    //    return raycastHit.collider != null;
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Player")
    //        spriteRenderer.sprite = smallCloud;

    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.collider.tag == "Player")
    //        spriteRenderer.sprite = fullCloud;
    //}
}
