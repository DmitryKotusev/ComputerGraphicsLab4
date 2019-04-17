using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadData : MonoBehaviour
{
    private float x = 0;
    private float z = 0;

    public void SetX(float x)
    {
        this.x = x;
    }

    public void SetZ(float z)
    {
        this.z = z;
    }

    public float GetX()
    {
        return x;
    }

    public float GetZ()
    {
        return z;
    }

    public void SetMaterial(Material material)
    {
        GetComponent<Renderer>().material = material;
    }

    public Material GetMaterial(Material material)
    {
        return GetComponent<Renderer>().material;
    }
}
