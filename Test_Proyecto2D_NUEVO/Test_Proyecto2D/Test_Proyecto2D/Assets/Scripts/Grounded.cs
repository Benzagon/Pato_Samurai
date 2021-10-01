using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

    GameObject Player;
        
	void Start () {
        Player = gameObject.transform.parent.gameObject;
	}
		
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform")
        {
            Player.GetComponent<Movement2D>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform")
        {
            Player.GetComponent<Movement2D>().isGrounded = false;
        }
    }
}
