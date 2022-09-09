using UnityEngine;

/// <summary>
/// When player ball touch this, Change all obstacles currently on screen to the player's color.
/// </summary>
public class PowerUp : MonoBehaviour
{
    [Tooltip("Obstacles that are supposed to change when power up activate.")]
    public string[] obstaclesNames;
    public Material playerMaterial;

    RaycastHit hit;
    Camera cam => Camera.main;
    int screenWidth => cam.pixelWidth;
    int screenHeight => cam.pixelHeight;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            ChangeAllObstaclesOnScreen();
    }

    private void ChangeAllObstaclesOnScreen()
    {
        for (int x = 0; x < screenWidth; x++)
        {
            for (int y = 0; y < screenHeight; y++)
            {
                CheckRayCollisionForEveryPixel(x, y);
            }
        }
    }

    /// <summary>
    /// Cast ray from Camera pixels 0,0 to the camera width and height to the scene world.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void CheckRayCollisionForEveryPixel(int x, int y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        Ray screenRay = cam.ScreenPointToRay(pos);

        if (Physics.Raycast(screenRay, out hit))
        {
            foreach (var obstacleName in obstaclesNames)
            {
                if (hit.collider.gameObject.name.Contains(obstacleName))
                    ChangeObstaclesToPostive();
            }
        }
    }

    /// <summary>
    /// Change obstacles to match the Postive Obstacle
    /// </summary>
    private void ChangeObstaclesToPostive()
    {
        GameObject hittedObstacle = hit.collider.gameObject;
        hittedObstacle.name = "Postive Obstacle";
        hittedObstacle.GetComponent<MeshRenderer>().material = playerMaterial;
        hittedObstacle.tag = "Untagged";
        Destroy(hittedObstacle.GetComponent<OnCollisionEvent>());

        Destroy(gameObject);
    }
}
