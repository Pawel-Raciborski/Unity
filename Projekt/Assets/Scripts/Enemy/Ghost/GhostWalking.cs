using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWalking : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    private Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, GhostMetadata.speed * Time.deltaTime);

        if (transform.position == nextPosition)
        {
            if (nextPosition == pointA.position)
            {
                nextPosition = pointB.position;
                transform.localScale = new Vector2(2.7536f, 2.7536f);
            }
            else
            {
                nextPosition = pointA.position;
                transform.localScale = new Vector2(-2.7536f, 2.7536f);
            }
        }
    }
}
