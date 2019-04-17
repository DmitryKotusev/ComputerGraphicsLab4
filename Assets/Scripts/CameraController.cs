using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] float minZoom = 3f;
    [SerializeField] float maxZoom = 12f;
    [SerializeField] Vector3 startCameraPosition = new Vector3(0, 12, 0);
    public float zoomStep = 0.5f;

    void Start()
    {
    }

    void Update()
    {
    }
}
