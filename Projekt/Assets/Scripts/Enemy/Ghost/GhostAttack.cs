using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    public float damage = 0.01f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collider.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                Vector2 pushDirection = (collider.transform.position - transform.position).normalized;
                playerRigidbody.AddForce(pushDirection * 5f, ForceMode2D.Impulse);
            }
            collider.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("playerEnter", true);
            PlayerHealth.Damage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("playerEnter", false);
            collider.gameObject.GetComponent<Animator>().ResetTrigger("Hurt");
        }
    }
}
