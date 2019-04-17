using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastAlgorithms : MonoBehaviour
{
    public static List<Vector2> StepByStep(int x1, int z1, int x2, int z2)
    {
        List<Vector2> resultList = new List<Vector2>();
        int distance = Mathf.Max(Mathf.Abs(z2 - z1), Mathf.Abs(x2 - x1));
        float step = (float)Mathf.Abs(x2 - x1) / distance;
        if ((x2 - x1) == 0)
        {
            for (int i = 0; i <= distance; i++)
            {
                if (z1 < z2)
                {
                    resultList.Add(new Vector2(x1, z1 + i));
                }
                else
                {
                    resultList.Add(new Vector2(x1, z1 - i));
                }
            }
            return resultList;
        }
        float k = CountK(x1, z1, x2, z2);
        float b = CountB(x1, z1, k);

        float x = x1;

        while(distance >= 0)
        {
            int z = Mathf.RoundToInt(k * x + b);
            resultList.Add(new Vector2(Mathf.RoundToInt(x), z));
            x += step;
            distance--;
        }

        return resultList;
    }

    public static List<Vector2> DigitalDifferentialAnalyzer(int x1, int z1, int x2, int z2)
    {
        List<Vector2> resultList = new List<Vector2>();
        int distance = Mathf.Max(Mathf.Abs(z2 - z1), Mathf.Abs(x2 - x1));
        
        if ((x2 - x1) == 0)
        {
            for (int j = 0; j <= distance; j++)
            {
                if (z1 < z2)
                {
                    resultList.Add(new Vector2(x1, z1 + j));
                }
                else
                {
                    resultList.Add(new Vector2(x1, z1 - j));
                }
            }
            return resultList;
        }

        float dx = x2 - x1;
        float dz = z2 - z1;
        resultList.Add(new Vector2(x1, z1));

        int i = 0;
        float x = x1;
        float z = z1;

        while (i < distance)
        {
            x = x + dx / distance;
            z = z + dz / distance;
            resultList.Add(new Vector2(Mathf.RoundToInt(x), Mathf.RoundToInt(z)));
            i++;
        }

        return resultList;
    }

    static float CountK(float x1, float z1, float x2, float z2)
    {
        return (z2 - z1) / (x2 - x1);
    }

    static float CountB(float x, float z, float k)
    {
        return z - k * x;
    }
}
