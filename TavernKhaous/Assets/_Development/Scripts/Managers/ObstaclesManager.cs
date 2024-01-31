using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] int minSpawn = 2;

    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject[] obstacles;

    List<GameObject> obstaclesList = new();

    public void SpawnObstacles()
    {
        int spawnCount = Random.Range(minSpawn, spawns.Length);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawns[i]);
            obstaclesList.Add(obstacle);
        }
    }

    public void RemoveObstacles()
    {
        for (int i = 0; i < obstaclesList.Count; i++)
        {
            Destroy(obstaclesList[i]);
        }

        obstaclesList.Clear();
    }
}
