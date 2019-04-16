using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool mouseWheelUp;
    public bool mouseWheelDown;

    private void Update()
    {
        mouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        mouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
    }
}
