using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelInstructions;
    public GameObject panelCredits;
    public GameObject panelLevelComplete;

    public Text Recipes;

    public GameObject[] levels;

    public static gameManager Instance { get; private set; }
    public enum State { MENU, LVLS, INST, CREDITS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;
    GameObject _currentLevel;
    bool _isSwitching;

    private int _levels;
    private float cont;

    public int Levels
    {
        get { return _levels; }
        set { _levels = value; }
    }




    void Start()
    {
        Instance = this;
        changeState(State.MENU);
        cont = 0;
    }

    public void ClickPlay()
    {
        changeState(State.INIT);
    }
    public void ClickInstructions()
    {
        changeState(State.INST);
    }
    public void ClickCredits()
    {
        changeState(State.CREDITS);
    }

    public void changeState(State newState, float delay = 0)
    {
        StartCoroutine(changeDelay(newState, delay));
    }

    IEnumerator changeDelay(State newState, float delay)
    {
        _isSwitching = true;
        yield return new WaitForSeconds(delay);
        finishCurrentState();
        _state = newState;
        startNewState(newState);
        _isSwitching = false;
    }



    void startNewState(State state)
    {
        switch (state)
        {
            case State.MENU:
                panelMenu.SetActive(true);
                break;
            case State.LVLS:
                break;
            case State.INST:
                panelInstructions.SetActive(true);
                break;
            case State.CREDITS:
                panelCredits.SetActive(true);
                break;
            case State.INIT:
                Levels = 0;
                panelPlay.SetActive(true);
                changeState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelComplete.SetActive(true);
                break;
            case State.LOADLEVEL:
                if (Levels >= levels.Length)
                {
                    changeState(State.GAMEOVER);
                }
                else
                {
                    Destroy(_currentLevel);
                    _currentLevel = Instantiate(levels[Levels]);
                    changeState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if (_currentLevel != null) Destroy(_currentLevel);
                changeState(State.MENU);
                break;
        }
    }

    void Update()
    {
        cont += Time.deltaTime;
        if (Input.GetKey(KeyCode.N) && cont >= 0.5)
        {
            ++Levels;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Escape) && cont >= 0.5)
        {
            changeState(State.GAMEOVER);
            cont = 0;
        }
    }

    void finishCurrentState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.LVLS:
                break;
            case State.INST:
                panelInstructions.SetActive(false);
                break;
            case State.CREDITS:
                panelCredits.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelComplete.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                break;
        }
    }
}
