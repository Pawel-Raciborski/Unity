using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    private int index = 1;
    public Vector3 originalPosition;
    public Vector3[] corners;

    // Start is called before the first frame update
    void Start()
    {
       originalPosition = transform.position;

       corners = new Vector3[]{
        new Vector3(0,0,0),
        new Vector3(0,0,10),
        new Vector3(10,0,10),
        new Vector3(10,0,0),
       };

       transform.position = corners[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = corners[index];
        Vector3 direction = (target - transform.position).normalized;

        transform.position += speed * Time.deltaTime * direction;

        if(Vector3.Distance(transform.position, target) < 0.1f){
            transform.Rotate(0,90,0);

            transform.position = target;

            index = (index + 1) % corners.Length;
        }
    }

}
