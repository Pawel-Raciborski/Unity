using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    public GameObject cube;
    public HashSet<Vector3> cubes = new();
    
    // Start is called before the first frame update
    void Start()
    {
        while(cubes.Count < 10){
            Vector3 generatedRandomVector = generateRandomVector(10,0,10);
            Instantiate(cube,generatedRandomVector,Quaternion.identity);
            cubes.Add(generatedRandomVector);
        }   
    }

    private Vector3 generateRandomVector(int xRange, int yRange, int zRange)
    {
        System.Random random = new System.Random();

        int randomX = random.Next(0,xRange + 1);
        int randomY = random.Next(0,yRange + 1);
        int randomZ = random.Next(0,zRange + 1);


        return new Vector3(randomX,randomY,randomZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
