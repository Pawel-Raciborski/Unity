using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public GameObject checkpointPopup;
    public GameObject finishPopup;
    public GameObject appleCollectPopup;
    private AppleCollect appleCollect;

    void Start()
    {
        appleCollect = gameObject.GetComponent<AppleCollect>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpointPopup.SetActive(true);
        }
        else if (collision.CompareTag("Endpoint") && appleCollect.hasCollectedAllApples)
        {
            finishPopup.SetActive(true);
        }
        else if (collision.CompareTag("Endpoint") && !appleCollect.hasCollectedAllApples)
        {
            appleCollectPopup.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpointPopup.SetActive(false);
        }
        else if (collision.CompareTag("Endpoint") && !appleCollect.hasCollectedAllApples)
        {
            appleCollectPopup.SetActive(false);
        }
    }
}
