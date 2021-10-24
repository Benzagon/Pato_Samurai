using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private LayerMask slimeLayerMask;
    [SerializeField] private LayerMask skeletonLayerMask;

    public float timeBtwAttack;
    public float startTimeBtwAttack;
    
    public Animator playerAnim;

    public Transform attackPos;
    public float attackRange;
    public int damage;

	void Start () {
		
	}

	void Update () {
		
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                playerAnim.SetTrigger("attack");

                Collider2D[] enemiesToDamageSlime = Physics2D.OverlapCircleAll(attackPos.position, attackRange, slimeLayerMask);
                for (int i = 0; i < enemiesToDamageSlime.Length; i++)
                {
                    enemiesToDamageSlime[i].GetComponent<SlimeMovement>().TakeDamage(damage);
                }

                Collider2D[] enemiesToDamageSkeleton = Physics2D.OverlapCircleAll(attackPos.position, attackRange, skeletonLayerMask);
                for (int i = 0; i < enemiesToDamageSkeleton.Length; i++)
                {
                    enemiesToDamageSkeleton[i].GetComponent<skeletonMovement>().TakeDamage(damage);
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
