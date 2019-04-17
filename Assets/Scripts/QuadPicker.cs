using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuadPicker : MonoBehaviour
{
    InputManager inputManager;
    LogicManager logicManager;

    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (inputManager.leftMouseButtonClick)
            {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {
                    logicManager.SelectQuad(hitInfo.transform.name);
                }
            }

            if (inputManager.rightMouseButtonClick)
            {
                logicManager.UnSelectQuads();
            }
        }
    }
}
