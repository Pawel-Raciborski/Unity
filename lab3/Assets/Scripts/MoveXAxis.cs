using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXAxis : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 originalPosition;
    bool forwardDirection = true;
    // Start is called before the first frame update
    void Start()
    {
       originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(forwardDirection){
            transform.position += new Vector3(speed*Time.deltaTime,0,0);

            if(Vector3.Distance(originalPosition,transform.position) >= speed){
                forwardDirection = false;
            }
        }
        else {
            transform.position -= new Vector3(speed*Time.deltaTime,0,0);

            if(Vector3.Distance(originalPosition,transform.position) <= 0.1f){
                forwardDirection = true;
            }
        }
    }
}
