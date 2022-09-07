using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCollector : MonoBehaviour
{
    public TextMeshProUGUI pointsUI;
    int pointsCollected;
    List<GameObject> collectedPointPickups = new List<GameObject>();


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Point"))
            CollectPointAndDestroyIt(collision);
    }

    private void CollectPointAndDestroyIt(Collision collision)
    {
        pointsCollected++;
        pointsUI.text = "" + pointsCollected;

        GameObject collectedPointPickup = collision.collider.gameObject;
        collectedPointPickups.Add(collectedPointPickup);
        collectedPointPickup.SetActive(false);
    }
    public void ResetPoints()
    {
        pointsCollected = 0;
        pointsUI.text = "" + pointsCollected;
    }
}
