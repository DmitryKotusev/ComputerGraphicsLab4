using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontalMouseInput;
    public float verticalMouseInput;
    public bool mouseWheelUp;
    public bool mouseWheelDown;
    public bool leftMouseButtonClick;
    public bool rightMouseButtonClick;
    public bool middleMouseButtonPress;

    private void Update()
    {
        horizontalMouseInput = Input.GetAxis("Mouse X");
        verticalMouseInput = Input.GetAxis("Mouse Y");
        mouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        mouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
        leftMouseButtonClick = Input.GetMouseButtonDown(0);
        rightMouseButtonClick = Input.GetMouseButtonDown(1);
        middleMouseButtonPress = Input.GetMouseButton(2);
    }
}
