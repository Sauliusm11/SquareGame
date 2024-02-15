using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Use these for selection
    public enum Selected
    {
        Camera, EmptySquare, RedSquare, TriangleUp, Hexagon, SimpleDot, Pillar, Star, DiagonalArrowRight, Cross, SpikeBall, QuestionMark,
        EmptySquareLocked, RedSquareLocked, TriangleUpLocked, HexagonLocked, SimpleDotLocked, PillarLocked,
        StarLocked, DiagonalArrowRightLocked, CrossLocked, SpikeBallLocked, QuestionMarkLocked, Removal
    };
    private static Selected selectedSquare;

    // Game states
    public enum State { LevelSelect, LevelCompleted, Settings, InGame }
    State state;

    //Level counter at the top of the screen
    public GameObject LevelCounter;
    public TextMeshProUGUI LevelCounterText;
    // Objects for state control
    public GameObject LevelSelector;
    public GameObject LevelSelect1;
    public GameObject LevelCompleted;
    public GameObject NextLevelButton;
    public GameObject Level;
    public GameObject SquareSelection1;
    public GameObject SquareSelection2;
    public GameObject RestartLevelButton;
    //public GameObject HintButton;
    //public GameObject SettingsCanvas;

    LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(State.LevelSelect);
        levelHandler = GameObject.Find("LevelHandler").GetComponent<LevelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedSquare(Selected selection)
    {
        selectedSquare = selection;
    }
    public Selected GetSelectedSquare()
    {
        return selectedSquare;
    }

    public void SwitchState(State newState)
    {
        EndState();
        BeginState(newState);
    }
    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.LevelSelect:
                LevelSelector.SetActive(true);
                LevelSelect1.SetActive(true);
                SquareSelection1.SetActive(false);
                SquareSelection2.SetActive(false);
                state = State.LevelSelect;
                RestartLevelButton.SetActive(false);
                LevelCounter.SetActive(false);
                //IsCurrentStatePlaying = false;
                break;
            case State.LevelCompleted:
                LevelCompleted.SetActive(true);
                if (levelHandler.NextLevelExists())
                {
                    NextLevelButton.SetActive(true);
                }
                else
                {
                    NextLevelButton.SetActive(false);
                }
                state = State.LevelCompleted;
                break;
            //case State.Settings:
            //    state = State.Settings;
            //    SquareSelection1.SetActive(false);
            //    SquareSelection2.SetActive(false);
            //    MainMenu.SetActive(true);
            //    SettingsCanvas.SetActive(true);
            //    RestartLevelButton.SetActive(false);
            //    LevelCounter.SetActive(false);
            //    IsCurrentStatePlaying = false;
            //    break;
            case State.InGame:
                Level.SetActive(true);
                if(!SquareSelection2.activeInHierarchy)
                SquareSelection1.SetActive(true);
                state = State.InGame;
                RestartLevelButton.SetActive(true);
                LevelCounterText.text = levelHandler.GetCurrentLevel().ToString();
                LevelCounter.SetActive(true);
                //IsCurrentStatePlaying = true;
                //HintButton.SetActive(true);
                break;
            default:
                break;
        }
    }

    void EndState()
    {
        switch (state)
        {
            case State.LevelSelect:
                LevelSelector.SetActive(false);
                LevelSelect1.SetActive(false);
                break;
            case State.LevelCompleted:
                LevelCompleted.SetActive(false);
                break;
            //case State.Settings:
            //    MainMenu.SetActive(true);
            //    SettingsCanvas.SetActive(false);
            //    break;
            case State.InGame:
                //ClearHints();
                Level.SetActive(false);
                //HintButton.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void LevelSelect()
    {
        SwitchState(State.LevelSelect);
    }
    public void ViewSolution()
    {
        SwitchState(State.InGame);
    }
    public void NextPage()
    {
        if (SquareSelection1.activeInHierarchy)
        {
            SquareSelection2.SetActive(true);
            SquareSelection1.SetActive(false);
        }
        else
        {
            SquareSelection1.SetActive(true);
            SquareSelection2.SetActive(false);
        }
    }

    //Might be useful if page three exists
    //public void PreviousPage()
    //{
    //    if (SquareSelection2.activeInHierarchy)
    //    {
    //        SquareSelection1.SetActive(true);
    //        SquareSelection2.SetActive(false);
    //    }
    //}
}
