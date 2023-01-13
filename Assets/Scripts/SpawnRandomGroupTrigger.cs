using UnityEngine;

namespace BallPhysicsGame
{
    public class SpawnRandomGroupTrigger : MonoBehaviour
    {
        [SerializeField] Transform parentTransform;
        [SerializeField] Transform groupSpawningPosition;
        [SerializeField] GameObject[] obstaclesGroups;

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
            GameObject randomGroup = obstaclesGroups[Random.Range(0, obstaclesGroups.Length)];
            GameObject spawnedGroup = Instantiate(randomGroup, parentTransform);

            spawnedGroup.transform.position = groupSpawningPosition.position;
            spawnedGroup.transform.rotation = groupSpawningPosition.rotation;
        }

        public void ResetTrigger()
        {
            boxCollider.enabled = true;
        }
    } 
}
