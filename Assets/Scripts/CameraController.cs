using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    InputManager inputManager;

    public float zoomSpeed = 0.2f;
    public float motionSpeed = 10f;
    [SerializeField] Texture2D grabHandTexture;
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
        if (inputManager.middleMouseButtonPress && !EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(grabHandTexture, Vector2.zero, CursorMode.Auto);
            HandleCameraMotion();
        }
        HandleCameraZoom();
    }

    void HandleCameraMotion()
    {
        Vector3 oldMousePosition = transform.localToWorldMatrix * Input.mousePosition;
        Vector3 motionVector = (new Vector3(-inputManager.horizontalMouseInput, -inputManager.verticalMouseInput, 0f)).normalized;
        transform.Translate(motionVector * motionSpeed * Time.deltaTime);
        Input.Mou
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
