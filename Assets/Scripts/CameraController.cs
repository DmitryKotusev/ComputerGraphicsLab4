using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField] float minDistanceToGrid = 3f;
    [SerializeField] float maxDistanceToGrid = 12f;
    [SerializeField] Vector2 boundaries = new Vector2(12, 12);
    [SerializeField] Vector3 startCameraPosition = new Vector3(0, 12, 0);
    public float zoomStep = 0.5f;

    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
    }

    void Update()
    {
        if (inputManager.middleMouseButtonPress)
        {
            HandleCameraMotion();
        }
    }

    void HandleCameraMotion()
    {

    }

    void HandleCameraZoom()
    {

    }
}
