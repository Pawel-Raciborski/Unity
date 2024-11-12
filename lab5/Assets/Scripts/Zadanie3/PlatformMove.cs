using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private List<Vector3> checkpoints = new();
    private int index = 1;
    public List<Vector3> waypoints = new();
    public Transform platform;
    private bool movingForward = false;
    private bool isMoving = false;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints.Add(transform.position);
        if (waypoints.Count < 1)
        {
            Debug.LogError("Trasa wymaga co najmniej jednego punktu docelowego.");
        }
        checkpoints.AddRange(waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        Vector3 target = checkpoints[index];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            if (IsLast())
            {
                movingForward = false;
            }
            else if (index == 0)
            {
                movingForward = true;
            }

            index = movingForward ? index + 1 : index - 1;
        }
    }

    private bool IsLast()
    {
        return index == checkpoints.Count - 1;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            isMoving = true;
            collider.gameObject.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł na windę.");
            isMoving = false;
            transform.position = checkpoints[0];
            collider.gameObject.transform.parent = null;
        }
    }
}
