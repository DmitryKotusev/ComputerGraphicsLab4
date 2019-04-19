using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public bool mouseWheelUp;
    public bool mouseWheelDown;
    public bool leftMouseButtonClick;
    public bool rightMouseButtonClick;
    public bool middleMouseButtonPress;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        mouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
        leftMouseButtonClick = Input.GetMouseButtonDown(0);
        rightMouseButtonClick = Input.GetMouseButtonDown(1);
        middleMouseButtonPress = Input.GetMouseButton(2);
    }
}
