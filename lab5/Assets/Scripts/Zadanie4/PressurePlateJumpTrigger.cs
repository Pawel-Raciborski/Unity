using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("WSZEDL NA PLATFORME");
            MoveWithCharacterController characterController = collider.GetComponent<MoveWithCharacterController>();

            if (characterController != null)
            {
                characterController.JumpWithForce(3.0f);
            }

        }
    }


}
