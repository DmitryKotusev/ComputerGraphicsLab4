﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastAlgorithms : MonoBehaviour
{
    public static List<Vector2> StepByStep(int x1, int z1, int x2, int z2)
    {
        // DateTime before = DateTime.Now;
        float startTime = Time.realtimeSinceStartup;
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
        // DateTime after = DateTime.Now;
        // TimeSpan duration = after.Subtract(before);
        Debug.Log("StepByStep duration in milliseconds: " + (Time.realtimeSinceStartup - startTime) * 1000);

        return resultList;
    }

    public static List<Vector2> DigitalDifferentialAnalyzer(int x1, int z1, int x2, int z2)
    {
        //DateTime before = DateTime.Now;
        float startTime = Time.realtimeSinceStartup;
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

        // DateTime after = DateTime.Now;
        // TimeSpan duration = after.Subtract(before);
        Debug.Log("DigitalDifferentialAnalyzer duration in milliseconds: " + (Time.realtimeSinceStartup - startTime) * 1000);
        return resultList;
    }

    public static List<Vector2> BresenhamsLine(int x1, int z1, int x2, int z2)
    {
        List<Vector2> resultList = new List<Vector2>();

        int a = z2 - z1;
        int b = x1 - x2;
        int signA, signB, sign;

        if (Mathf.Abs(a) > Mathf.Abs(b))
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }

        if (a < 0)
        {
            signA = -1;
        }
        else
        {
            signA = 1;
        }

        if (b < 0)
        {
            signB = -1;
        }
        else
        {
            signB = 1;
        }

        int f = 0;
        int x = x1;
        int z = z1;
        resultList.Add(new Vector2(x, z));

        if(sign == -1)
        {
            do
            {
                f = f + a * signA;

                if (f > 0)
                {
                    f = f - b * signB;
                    z = z + signA;
                }
                x = x - signB;
                resultList.Add(new Vector2(x, z));
            }
            while (x != x2 || z != z2);
        }
        else
        {
            do
            {
                f = f + b * signB;

                if (f > 0)
                {
                    f = f - a * signA;
                    x = x - signB;
                }
                z = z + signA;
                resultList.Add(new Vector2(x, z));
            }
            while (x != x2 || z != z2);
        }

        return resultList;
    }

    public static List<Vector2> BresenhamsLine2(int x1, int z1, int x2, int z2)
    {
        // DateTime before = DateTime.Now;
        float startTime = Time.realtimeSinceStartup;
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

        int deltax = Mathf.Abs(x2 - x1);
        int deltaz = Mathf.Abs(z2 - z1);

        if (deltax >= deltaz)
        {
            int error = 0;
            int deltaerr = deltaz;
            int z = z1;
            int dirz = z2 - z1;
            if (dirz > 0)
                dirz = 1;
            if (dirz < 0)
                dirz = -1;
            for (int x = x1; x <= x2; x++)
            {
                resultList.Add(new Vector2(x, z));
                error = error + deltaerr;
                if (2 * error >= deltax)
                {
                    z = z + dirz;
                    error = error - deltax;
                }
            }
            // DateTime after = DateTime.Now;
            // TimeSpan duration = after.Subtract(before);
            Debug.Log("BresenhamsLine duration in milliseconds: " + (Time.realtimeSinceStartup - startTime) * 1000);
            return resultList;
        }
        else
        {
            int error = 0;
            int deltaerr = deltax;
            int x = x1;
            int dirx = x2 - x1;
            if (dirx > 0)
                dirx = 1;
            if (dirx < 0)
                dirx = -1;
            for (int z = z1; z <= z2; z++)
            {
                resultList.Add(new Vector2(x, z));
                error = error + deltaerr;
                if (2 * error >= deltaz)
                {
                    x = x + dirx;
                    error = error - deltaz;
                }
            }
            // DateTime after = DateTime.Now;
            // TimeSpan duration = after.Subtract(before);
            Debug.Log("BresenhamsLine duration in milliseconds: " + (Time.realtimeSinceStartup - startTime) * 1000);
            return resultList;
        }
    }

    public static List<Vector2> BresenhamsLineForTheCirle(int roundX, int roundZ, int centerX, int centerZ)
    {
        // DateTime before = DateTime.Now;
        float startTime = Time.realtimeSinceStartup;
        List<Vector2> resultList = new List<Vector2>();

        float r = Mathf.Sqrt((centerX - roundX) * (centerX - roundX) + (centerZ - roundZ) * (centerZ - roundZ));

        resultList.Add(new Vector2(centerX, centerZ));

        int x = 0;
        int z = Mathf.RoundToInt(r);
        float e = 3 - 2 * r;
        AddOctantPixel(x, z, centerX, centerZ, resultList);
        while (x < z)
        {
            if(e >= 0)
            {
                e = e + 4 * (x - z) + 10;
                x = x + 1;
                z = z - 1;
            }
            else
            {
                e = e + 4 * x + 6;
                x = x + 1;
            }
            AddOctantPixel(x, z, centerX, centerZ, resultList);
        }

        // DateTime after = DateTime.Now;
        // TimeSpan duration = after.Subtract(before);
        Debug.Log("BresenhamsLineForTheCirle duration in milliseconds: " + (Time.realtimeSinceStartup - startTime) * 1000);
        return resultList;
    }

    static void AddOctantPixel(int x, int z, int centerX, int centerZ, List<Vector2> resultList)
    {
        resultList.Add(new Vector2(centerX + x, centerZ + z)); // 2
        resultList.Add(new Vector2(centerX + x, centerZ - z)); // 7
        resultList.Add(new Vector2(centerX - x, centerZ + z)); // 3
        resultList.Add(new Vector2(centerX - x, centerZ - z)); // 5

        resultList.Add(new Vector2(centerX + z, centerZ + x)); // 1
        resultList.Add(new Vector2(centerX + z, centerZ - x)); // 8
        resultList.Add(new Vector2(centerX - z, centerZ + x)); // 4
        resultList.Add(new Vector2(centerX - z, centerZ - x)); // 6
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
