using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomGroupTrigger : MonoBehaviour
{
    public Transform parentTransform;
    public Transform groupSpawningPosition;
    public GameObject[] obstaclesGroups;

    private BoxCollider boxCollider => GetComponent<BoxCollider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnRandomObstaclesGroup();
            boxCollider.enabled = false;
        }
    }

    private void SpawnRandomObstaclesGroup()
    {
        GameObject randomGroup = obstaclesGroups[Random.Range(0, obstaclesGroups.Length - 1)];
        GameObject spawnedGroup = Instantiate(randomGroup, parentTransform);

        spawnedGroup.transform.position = groupSpawningPosition.position;
        spawnedGroup.transform.rotation = groupSpawningPosition.rotation;
    }

    public void ResetTrigger()
    {
        boxCollider.enabled = true;
    }
}
