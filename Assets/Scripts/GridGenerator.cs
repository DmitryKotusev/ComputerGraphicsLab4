using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public Material unTouchedMaterial;
    public Material selectedMaterial;
    public Material markedMaterial;
    public GameObject tilePrefab;
    public int verticalSize = 10;
    public int horizontalSize = 20;
    public float tileSize = 1f;
    public Dictionary<string, QuadData> quads;

    private void Awake()
    {
        quads = new Dictionary<string, QuadData>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < horizontalSize; i++)
        {
            for (int j = 0; j < verticalSize; j++)
            {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        spawnTile(i * tileSize + 0.5f, j * tileSize + 0.5f);
                    }
                    else
                    {
                        spawnTile(i * tileSize + 0.5f, j * tileSize + 0.5f);
                        spawnTile(i * tileSize + 0.5f, -j * tileSize + 0.5f);
                    }
                }
                else
                {
                    if (j == 0)
                    {
                        spawnTile(i * tileSize + 0.5f, j * tileSize + 0.5f);
                        spawnTile(-i * tileSize + 0.5f, j * tileSize + 0.5f);
                    }
                    else
                    {
                        spawnTile(i * tileSize + 0.5f, j * tileSize + 0.5f);
                        spawnTile(-i * tileSize + 0.5f, j * tileSize + 0.5f);
                        spawnTile(i * tileSize + 0.5f, -j * tileSize + 0.5f);
                        spawnTile(-i * tileSize + 0.5f, -j * tileSize + 0.5f);
                    }
                }
            }
        }
    }

    public QuadData GetQuad(string key)
    {
        return quads[key];
    }

    public void CleanGrid()
    {
        foreach(string key in quads.Keys)
        {
            quads[key].SetMaterial(unTouchedMaterial);
        }
    }

    public void SelectQuad(string key)
    {
        quads[key].SetMaterial(selectedMaterial);
    }

    public void UnSelectQuad(string key)
    {
        quads[key].SetMaterial(unTouchedMaterial);
    }

    public void MarkQuads(string[] keys)
    {
        foreach (string key in keys)
        {
            quads[key].SetMaterial(markedMaterial);
        }
    }

    public void MarkQuad(string key)
    {
        quads[key].SetMaterial(markedMaterial);
    }

    void spawnTile(float x, float z)
    {
        GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0f, z), tilePrefab.transform.rotation, transform);
        tile.name = (x - 0.5f) + " " + (z - 0.5f);
        QuadData data = tile.GetComponent<QuadData>();
        data.SetX(x - 0.5f);
        data.SetZ(z - 0.5f);
        quads.Add(tile.name, data);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var point = new Vector3(0f, 0f, 0f);
        Gizmos.DrawSphere(point, 0.5f);
    }
}
