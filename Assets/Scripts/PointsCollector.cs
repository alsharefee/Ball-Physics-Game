using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCollector : MonoBehaviour
{
    public TextMeshProUGUI pointsUI;
    [HideInInspector] public int pointsCollected;
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
        Destroy(collectedPointPickup);
    }
    public void ResetPoints()
    {
        pointsCollected = 0;
        pointsUI.text = "" + pointsCollected;
    }
}
