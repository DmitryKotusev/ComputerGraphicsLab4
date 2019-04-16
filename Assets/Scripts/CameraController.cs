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
    Camera camera;

    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        camera = GetComponent<Camera>();
        transform.position = startCameraPosition;
        Debug.Log(camera.orthographicSize);
    }

    void Update()
    {
        if(inputManager.mouseWheelUp)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
            Debug.Log(camera.orthographicSize);
        }
        else if (inputManager.mouseWheelDown)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), -1);
            Debug.Log(camera.orthographicSize);
        }
    }

    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
    {
        // Calculate how much we will have to move towards the zoomTowards position
        float multiplier = (1.0f / this.camera.orthographicSize * amount);

        // Move camera
        transform.position += (zoomTowards - transform.position) * multiplier;

        // Zoom camera
        camera.orthographicSize -= amount;

        // Limit zoom
        camera.orthographicSize = Mathf.Clamp(this.camera.orthographicSize, minZoom, maxZoom);
    }
}
