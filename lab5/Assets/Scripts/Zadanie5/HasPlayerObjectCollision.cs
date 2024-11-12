using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPlayerObjectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("ObstacleTag"))
        {
            Debug.Log("Wykryto zderzenie z przeszkodą z tagiem ObstacleTag " + hit.gameObject.name);
        }
    }
}
