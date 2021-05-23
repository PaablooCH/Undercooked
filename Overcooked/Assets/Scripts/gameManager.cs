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

    public GameObject[] lvl1recipes;

    public GameObject[] lvl2recipes;

    public static gameManager Instance { get; private set; }
    public enum State { MENU, LVLS, INST, CREDITS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER, NEXT_RECIPE }
    State _state;
    GameObject _currentLevel;
    GameObject _currentRecipe;
    GameObject[] currentlvlrecipes;
    bool _isSwitching;

    private int _levels;
    private float cont;

    public int Levels
    {
        get { return _levels; }
        set { _levels = value; }
    }

    private int _currentRecipes;

    public int CurrentRecipes
    {
        get { return _currentRecipes; }
        set { _currentRecipes = value; }
    }


    private int _lvl1recipes;

    public int Lvl1Recipes
    {
        get { return _lvl1recipes; }
        set { _lvl1recipes = value; }
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

    public bool checkRecipe(GameObject f)
    {
        if (f.name == _currentRecipe.name) return true;
        return false;
    }

    public void nextRecipe()
    {
        ++CurrentRecipes;
        changeState(State.NEXT_RECIPE);
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
                CurrentRecipes = 0;
                currentlvlrecipes = lvl1recipes;
                panelPlay.SetActive(true);
                _currentRecipe = Instantiate(lvl1recipes[Lvl1Recipes], panelPlay.transform);
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
                    Destroy(_currentRecipe);
                    CurrentRecipes = 0;
                    _currentLevel = Instantiate(levels[Levels]);
                    _currentRecipe = Instantiate(currentlvlrecipes[CurrentRecipes], panelPlay.transform);
                    changeState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if (_currentLevel != null) Destroy(_currentLevel);
                changeState(State.MENU);
                break;
            case State.NEXT_RECIPE:
                if (CurrentRecipes >= currentlvlrecipes.Length)
                {
                    ++Levels;
                    if (Levels == 1) currentlvlrecipes = lvl2recipes;
                    //if (Levels == 2)
                    //if (Levels == 3)
                    //if (Levels == 4)
                    changeState(State.LOADLEVEL);
                }
                else
                {
                    Destroy(_currentRecipe);
                    _currentRecipe = Instantiate(currentlvlrecipes[CurrentRecipes], panelPlay.transform);
                    changeState(State.PLAY);
                }
                break;
        }
    }

    void Update()
    {
        cont += Time.deltaTime;
        if (Input.GetKey(KeyCode.N) && cont >= 0.5)
        {
            ++Levels;
            if (Levels == 1) currentlvlrecipes = lvl2recipes;
            //if (Levels == 2)
            //if (Levels == 3)
            //if (Levels == 4)
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
            case State.NEXT_RECIPE:
                break;
        }
    }
}
