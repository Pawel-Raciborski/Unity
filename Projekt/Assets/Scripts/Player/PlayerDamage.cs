using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            PlayerHealth.Damage(0.05f);
            Debug.Log("DAMAGE FROM TRAP: " + PlayerHealth.health);
        }
    }
}
