using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{

    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                anim.SetTrigger("Attack1");
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    damage[i].gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    Destroy(damage[i].gameObject);
                }
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            anim.ResetTrigger("Attack1");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
