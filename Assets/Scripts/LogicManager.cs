using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    TMP_Dropdown selector;
    [SerializeField]
    AppStates state;
    GridGenerator grid;
    QuadData firstSelectedQuad;
    QuadData secondSelectedQuad;

    private void Start()
    {
        selector = GetComponentInChildren<TMP_Dropdown>();
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridGenerator>();
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickCleanButton()
    {
        grid.CleanGrid();
        UnSelectQuads();
    }

    public void OnSelectAlgorithm()
    {
        switch (selector.value)
        {
            case 0:
                {
                    state = AppStates.STEP_BY_STEP_ALGORITHM;
                    break;
                }
            case 1:
                {
                    state = AppStates.DIGIGTAL_DIFFERNTIAL_ANALYZER_ALGORITHM;
                    break;
                }
            case 2:
                {
                    state = AppStates.BRESENHAMS_LINE_ALGORITHM;
                    break;
                }
            case 3:
                {
                    state = AppStates.BRESENHAMS_LINE_ALGORITHM_FOR_THE_CIRCLE;
                    break;
                }
        }
    }

    public void SelectQuad(string key)
    {
        if (firstSelectedQuad == null)
        {
            grid.SelectQuad(key);
            firstSelectedQuad = grid.GetQuad(key);
            return;
        }
        grid.SelectQuad(key);
        secondSelectedQuad = grid.GetQuad(key);

        if (firstSelectedQuad != secondSelectedQuad)
        {
            ExecuteAlgorithmLogic();
            return;
        }
        secondSelectedQuad = null;
    }

    public void UnSelectQuads()
    {
        if (firstSelectedQuad != null)
        {
            grid.UnSelectQuad(firstSelectedQuad.GetX() + " " + firstSelectedQuad.GetZ());
            firstSelectedQuad = null;
        }
        if (secondSelectedQuad != null)
        {
            grid.UnSelectQuad(secondSelectedQuad.GetX() + " " + secondSelectedQuad.GetZ());
            secondSelectedQuad = null;
        }
    }

    private void ExecuteAlgorithmLogic()
    {
        // grid.CleanGrid();
        List<Vector2> squadsToMark;
        switch (state)
        {
            case AppStates.STEP_BY_STEP_ALGORITHM:
                {
                    grid.ShowCoordinates(firstSelectedQuad.GetX() + " " + firstSelectedQuad.GetZ());
                    grid.ShowCoordinates(secondSelectedQuad.GetX() + " " + secondSelectedQuad.GetZ());
                    if (firstSelectedQuad.GetX() < secondSelectedQuad.GetX())
                    {
                        squadsToMark = RastAlgorithms.StepByStep((int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ(),
                            (int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ());
                        break;
                    }
                    else
                    {
                        squadsToMark = RastAlgorithms.StepByStep((int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ(),
                            (int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ());
                        break;
                    }

                }
            case AppStates.DIGIGTAL_DIFFERNTIAL_ANALYZER_ALGORITHM:
                {
                    grid.ShowCoordinates(firstSelectedQuad.GetX() + " " + firstSelectedQuad.GetZ());
                    grid.ShowCoordinates(secondSelectedQuad.GetX() + " " + secondSelectedQuad.GetZ());
                    if (firstSelectedQuad.GetX() < secondSelectedQuad.GetX())
                    {
                        squadsToMark = RastAlgorithms.DigitalDifferentialAnalyzer((int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ(),
                            (int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ());
                        break;
                    }
                    else
                    {
                        squadsToMark = RastAlgorithms.DigitalDifferentialAnalyzer((int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ(),
                            (int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ());
                        break;
                    }
                }
            case AppStates.BRESENHAMS_LINE_ALGORITHM:
                {
                    grid.ShowCoordinates(firstSelectedQuad.GetX() + " " + firstSelectedQuad.GetZ());
                    grid.ShowCoordinates(secondSelectedQuad.GetX() + " " + secondSelectedQuad.GetZ());
                    if (Mathf.Abs(firstSelectedQuad.GetX() - secondSelectedQuad.GetX()) > Mathf.Abs(firstSelectedQuad.GetZ() - secondSelectedQuad.GetZ()))
                    {
                        if (firstSelectedQuad.GetX() < secondSelectedQuad.GetX())
                        {
                            squadsToMark = RastAlgorithms.BresenhamsLine2((int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ(),
                                (int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ());
                            break;
                        }
                        else
                        {
                            squadsToMark = RastAlgorithms.BresenhamsLine2((int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ(),
                                (int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ());
                            break;
                        }
                    }
                    else
                    {
                        if (firstSelectedQuad.GetZ() < secondSelectedQuad.GetZ())
                        {
                            squadsToMark = RastAlgorithms.BresenhamsLine2((int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ(),
                                (int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ());
                            break;
                        }
                        else
                        {
                            squadsToMark = RastAlgorithms.BresenhamsLine2((int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ(),
                                (int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ());
                            break;
                        }
                    }
                }
            case AppStates.BRESENHAMS_LINE_ALGORITHM_FOR_THE_CIRCLE:
                {
                    squadsToMark = RastAlgorithms.BresenhamsLineForTheCirle((int)firstSelectedQuad.GetX(), (int)firstSelectedQuad.GetZ(),
                            (int)secondSelectedQuad.GetX(), (int)secondSelectedQuad.GetZ());
                    grid.ShowCoordinates(secondSelectedQuad.GetX() + " " + secondSelectedQuad.GetZ());
                    break;
                }
            default:
                {
                    return;
                }
        }

        UnSelectQuads();

        foreach (Vector2 coordinates in squadsToMark)
        {
            grid.MarkQuad(coordinates.x + " " + coordinates.y);
        }
    }
}
