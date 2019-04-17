using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    GameObject tilePrefab;
    public int verticalSize = 10;
    public int horizontalSize = 20;

    void generateGrid()
    {
        for (int i = 0; i < verticalSize; i++)
        {
            for (int j = 0; j < horizontalSize; j++)
            {

            }
        }
    }

    void spawnTile(int x, int z)
    {
        GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0f, z), tilePrefab.transform.rotation);
        tile.transform.position = new Vector3(x, 0f, z);
    }
}
