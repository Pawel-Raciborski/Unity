using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFocus : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Vector2 dest = new Vector2(collider.gameObject.transform.position.x + 0.5f,
            enemy.transform.position.y
            );

            enemy.transform.position = Vector2.MoveTowards(
                enemy.transform.position,
                dest,
                0.2f
            );
        }
    }
}
