using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Collect points and show the count on the UI.
/// </summary>
namespace BallPhysicsGame
{
    public class PointsCollector : MonoBehaviour
    {
        public TextMeshProUGUI _pointsUI;
        [HideInInspector] public int PointsCollected;
        List<GameObject> _collectedPointPickups = new List<GameObject>();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Point"))
                CollectPointAndDestroyIt(collision);
        }

        private void CollectPointAndDestroyIt(Collision collision)
        {
            PointsCollected++;
            _pointsUI.text = "" + PointsCollected;

            GameObject collectedPointPickup = collision.collider.gameObject;
            _collectedPointPickups.Add(collectedPointPickup);
            Destroy(collectedPointPickup);
        }
        public void ResetPoints()
        {
            PointsCollected = 0;
            _pointsUI.text = "" + PointsCollected;
        }
    } 
}
