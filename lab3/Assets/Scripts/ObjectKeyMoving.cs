using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKeyMoving : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = speed * Time.deltaTime * velocity.normalized;
        
        rb.MovePosition(transform.position + velocity);
    }
}
