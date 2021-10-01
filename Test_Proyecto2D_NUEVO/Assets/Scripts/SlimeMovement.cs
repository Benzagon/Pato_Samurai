using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour {

    [SerializeField] private LayerMask groundLayerMask;

    public float slimeMoveSpeed;
    public float slimeJumpHeight;

    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
	}
		
	void Update () {

        rb2d.velocity = new Vector2(-slimeMoveSpeed, rb2d.velocity.y);

        if(isGrounded())
            rb2d.velocity = Vector2.up * slimeJumpHeight;

    }

    private bool isGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightText, groundLayerMask);

        //Debug.DrawRay(bc2d.bounds.center, Vector2.down *)

        return raycastHit.collider != null;
    }
}
