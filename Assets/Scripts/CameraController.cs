using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    InputManager inputManager;

    public float zoomSpeed = 0.2f;
    public float motionSpeed = 10f;
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            HandleCameraMotion();
        }
        HandleCameraZoom();
    }

    void HandleCameraMotion()
    {
        Vector3 oldMousePosition = transform.localToWorldMatrix * Input.mousePosition;
        Vector3 motionVector = (new Vector3(inputManager.horizontalInput, 0f, inputManager.verticalInput)).normalized;
        Vector3 newPossiblePosition = transform.position + motionVector * motionSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(Mathf.Clamp(newPossiblePosition.x, -boundaries.x, boundaries.x),
            newPossiblePosition.y, Mathf.Clamp(newPossiblePosition.z, -boundaries.y, boundaries.y));
        transform.position = newPosition;
    }

    void HandleCameraZoom()
    {
        float newY = transform.position.y;
        if (inputManager.mouseWheelDown)
        {
            newY += zoomSpeed * Time.deltaTime;
        }
        if (inputManager.mouseWheelUp)
        {
            newY -= zoomSpeed * Time.deltaTime;
        }
        newY = Mathf.Clamp(newY, minDistanceToGrid, maxDistanceToGrid);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
