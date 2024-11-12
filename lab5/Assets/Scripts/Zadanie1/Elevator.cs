using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    public bool isRunning = false;
    public float distance = 6.6f;
    public Vector3 destination;
    public bool isPlatformMovingTowards = true;
    public Vector3 originalPosition;
    public Vector3 currentPosition;
    private Transform oldParent;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (isRunning)
        {
            currentPosition = transform.position;
            if (Vector3.Distance(currentPosition, destination) <= 0.01f)
            {
                isPlatformMovingTowards = !isPlatformMovingTowards;
                updatePositions();
                return;
            }
            transform.position = Vector3.MoveTowards(currentPosition, destination, elevatorSpeed * Time.deltaTime);
        }

    }

    private void updatePositions()
    {
        Vector3 tmp = originalPosition;
        originalPosition = destination;
        destination = tmp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            if (isPlatformMovingTowards)
            {
                elevatorSpeed = -elevatorSpeed;
            }
            else
            {
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            isRunning = false;
            other.gameObject.transform.parent = null;
        }
    }
}
