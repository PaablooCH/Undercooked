using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text levelText;
    public Text godModeText;

    public GameObject panelMenu;
    //public GameObject panelPlay;
    //public GameObject panelLevels;
    //public GameObject panelLevelCompleted;
    //public GameObject panelGameOver;
    //public GameObject panelInstructions;
    //public GameObject panelCredits;

    public GameObject[] levels;

    public GameObject menuScene;

    public static gameManager Instance { get; private set; }

    public enum State { MENU, LVLS, INST, CREDITS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;
    GameObject _currentLevel;
    GameObject _menuScene;

    private int _level;
    private bool _godMode;

    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            levelText.text = "LEVEL: " + (_level + 1);
        }
    }

    /*public bool GodMode
    {
        get { return _godMode; }
        set
        {
            _godMode = value;
            if (_godMode) godModeText.text = "GODMODE: ON";
            else godModeText.text = "GODMODE: OFF";
        }
    }*/

    public void PlayClicked()
    {
        Level = 0;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void MenuClicked()
    {
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.MENU, 0f);
    }

    public void LevelsClicked()
    {
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.LVLS, 0f);
    }

    public void InstClicked()
    {
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INST, 0f);
    }

    public void CreditsClicked()
    {
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.CREDITS, 0f);
    }

    public void Level1Clicked()
    {
        Level = 0;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void Level2Clicked()
    {
        Level = 1;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void Level3Clicked()
    {
        Level = 2;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void Level4Clicked()
    {
        Level = 3;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void Level5Clicked()
    {
        Level = 4;
        //GameSounds.Instance.playClickButtonMenu();
        changeState(State.INIT, 0f);
    }

    public void ExitClicked()
    {
        //GameSounds.Instance.playClickButtonMenu();
        Application.Quit();
    }

    void Start()
    {
        Instance = this;
        _menuScene = Instantiate(menuScene);
        //GodMode = false;
        changeState(State.MENU, 0f);
    }


    public void changeState(State newState, float time)
    {
        StartCoroutine(changeStateTime(newState, time));
    }

    IEnumerator changeStateTime(State newState, float time)
    {
        yield return new WaitForSeconds(time);
        finishCurrentState();
        _state = newState;
        startNewState(newState);
    }

    private void changeToMenu()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
        }
        if (_menuScene == null)
        {
            _menuScene = Instantiate(menuScene);
        }
        changeState(State.MENU, 0f);
    }

    void startNewState(State state)
    {
        switch (state)
        {
            case State.MENU:
                Cursor.visible = true;
                panelMenu.SetActive(true);
                //GameSounds.Instance.playTitleTheme();
                break;
            case State.LVLS:
                //panelLevels.SetActive(true);
                break;
            case State.INST:
                //panelInstructions.SetActive(true);
                break;
            case State.CREDITS:
                Cursor.visible = true;
                //panelCredits.SetActive(true);
                break;
            case State.INIT:
                Cursor.visible = false;
                //panelPlay.SetActive(true);
                if (_currentLevel != null)
                {
                    Destroy(_currentLevel);
                }
                changeState(State.LOADLEVEL, 0f);
                break;
            case State.PLAY:
                //panelPlay.SetActive(true);
                //GameSounds.Instance.playMainTheme();
                break;
            case State.LEVELCOMPLETED:
                Destroy(_currentLevel);
                _menuScene = Instantiate(menuScene);
                Level++;
                float timeS = 0f;
                if (Level < levels.Length)
                {
                    //panelLevelCompleted.SetActive(true);
                    timeS = 2f;
                }
                changeState(State.LOADLEVEL, timeS);
                break;
            case State.LOADLEVEL:
                //GodMode = false;
                if (Level >= levels.Length)
                {
                    changeState(State.GAMEOVER, 0f);
                }
                else
                {
                    Destroy(_menuScene);
                    _currentLevel = Instantiate(levels[Level]);
                    changeState(State.PLAY, 0f);
                }
                break;
            case State.GAMEOVER:
                //GameSounds.Instance.playEndGameTheme();
                //panelGameOver.SetActive(true);
                changeState(State.CREDITS, 2.5f);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _state == State.MENU)
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _state != State.MENU && _state != State.LEVELCOMPLETED && _state != State.GAMEOVER)
        {
            changeToMenu();
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
                //panelLevels.SetActive(false);
                break;
            case State.INST:
                //panelInstructions.SetActive(false);
                break;
            case State.CREDITS:
                //panelCredits.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                //panelPlay.SetActive(false);
                break;
            case State.LEVELCOMPLETED:
                //panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                //panelPlay.SetActive(false);
                //panelGameOver.SetActive(false);
                break;
        }
    }
}
