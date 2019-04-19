using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuadData : MonoBehaviour
{
    TextMeshPro text;
    private float x = 0;
    private float z = 0;

    public void SetText(TextMeshPro text)
    {
        this.text = text;
    }

    public TextMeshPro GetText()
    {
        return text;
    }

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
