using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    List<GameObject> obstacles = new List<GameObject>();


    public void ResetObstacles()
    {
        SaveAllObstacles();
        DeleteAllObstacles();
    }
    private void SaveAllObstacles()
    {
        Transform[] AllObstacles = GetComponentsInChildren<Transform>();

        for (int i = 1; i < AllObstacles.Length; i++)
        {
            GameObject child = AllObstacles[i].gameObject;
            obstacles.Add(child);
        }
    }

    private void DeleteAllObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            Destroy(obstacles[i]);
        }
    }
}
