using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private LayerMask enemyLayerMask;

    public float timeBtwAttack;
    public float startTimeBtwAttack;
    //public Animator camAnim;
    public Animator playerAnim;

    public Transform attackPos;
    public float attackRange;
    public int damage;

	void Start () {
		
	}

	void Update () {
		
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                //camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("attack");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayerMask);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<SlimeMovement>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }           
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
