using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public float movingSpeed = 2.0f;
    public bool isOpen = false;

    public float distance = 2.5f;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isOpen = false;
        }
    }

    private void MoveDoor()
    {
        Vector3 target;
        if (isOpen)
        {
            target = originalPosition + new Vector3(0, 0, distance);
        }
        else
        {
            target = originalPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, movingSpeed * Time.deltaTime);

    }
}
