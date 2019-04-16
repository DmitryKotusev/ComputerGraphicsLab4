using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown selector;

    private void Start()
    {
        selector = GetComponentInChildren<TMP_Dropdown>();
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickCleanButton()
    {
    }

    public void OnSelectAlgorithm()
    {
        Debug.Log(selector.value);
    }
}
