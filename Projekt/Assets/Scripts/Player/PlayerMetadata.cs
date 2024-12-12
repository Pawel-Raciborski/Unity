
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMetadata : MonoBehaviour
{
    public static float damage = 25f;
    public Vector3 playerCheckpoint;
    public Transform fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        playerCheckpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.health <= 0)
        {
            transform.position = playerCheckpoint;
            PlayerHealth.health = 100;
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            playerCheckpoint = transform.position;
        }
        else if (collision.CompareTag("FallDetector"))
        {
            transform.position = playerCheckpoint;
        }
        else if (collision.CompareTag("Lava"))
        {
            transform.position = playerCheckpoint;
        }
        else if (collision.CompareTag("Endpoint"))
        {
            Debug.Log("KONIEC");
        }
    }



}
