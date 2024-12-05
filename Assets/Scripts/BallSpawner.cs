using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn;
    public Vector3 spawnOffset = new Vector3(2.0f, 0.0f, 2.0f);
    public int gridSize = 3;

    private GameObject[,] gridInstances;

    void Start()
    {
        SpawnGrid();
    }

    public void SpawnGrid()
    {
        // Calculate the starting position to center the grid
        Vector3 startPos = transform.position - new Vector3((gridSize - 1) * spawnOffset.x / 2, 0, (gridSize - 1) * spawnOffset.z / 2);

        // Destroy old instances if they exist
        if (gridInstances != null)
        {
            foreach (var instance in gridInstances)
            {
                Destroy(instance);
            }
        }

        gridInstances = new GameObject[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 spawnPosition = startPos + new Vector3(i * spawnOffset.x, 0, j * spawnOffset.z);
                gridInstances[i, j] = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                gridInstances[i, j].transform.parent = transform;
            }
        }
    }
}
