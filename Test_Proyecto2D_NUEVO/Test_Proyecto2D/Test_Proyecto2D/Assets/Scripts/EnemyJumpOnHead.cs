using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpOnHead : MonoBehaviour {

    GameObject Enemy1;

	void Start () {
        Enemy1 = gameObject.transform.parent.gameObject;
    }

	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(Enemy1);
    }
}
