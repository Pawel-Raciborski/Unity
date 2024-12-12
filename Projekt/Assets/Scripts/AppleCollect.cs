using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollect : MonoBehaviour
{
    public int collectedApples = 0;
    public Text scoreText;
    public int totalApples;
    public bool hasCollectedAllApples = false;
    public GameObject[] all;

    void Start()
    {
        all = GameObject.FindGameObjectsWithTag("Apple");
        totalApples = all.Count();
        scoreText.text = collectedApples + " / " + totalApples;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Apple"))
        {
            ++collectedApples;
            Destroy(collider.gameObject);
            scoreText.text = scoreText.text = collectedApples + " / " + totalApples;

            hasCollectedAllApples = collectedApples >= totalApples;
        }
    }


}
