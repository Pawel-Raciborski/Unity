using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public int numberOfObjectsToGenerate = 0;
    public GameObject block;
    public Vector3 max;
    public Vector3 min;

    void Start()
    {
        
        Bounds planeBounds = GetComponent<Collider>().bounds;

        max = planeBounds.max;
        min = planeBounds.min;

        List<int> xPositions = generatePositions((int) min.x, (int) max.x);
        List<int> zPositions = generatePositions((int) min.x, (int) max.x);
        
        Debug.Log("Array values: " + string.Join(", ", xPositions));
        Debug.Log("Array values: " + string.Join(", ", zPositions));
        
        for(int i=0; i<numberOfObjectsToGenerate; i++)
        {
            this.positions.Add(new Vector3(xPositions[i], 0.5f, zPositions[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    private List<int> generatePositions(int min, int max)
    {
        HashSet<int> positions = new HashSet<int>();
        System.Random random = new System.Random();


        while(positions.Count < numberOfObjectsToGenerate){
            int position = random.Next(min,max);
            positions.Add(position);
        }

        return new List<int>(positions);
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
