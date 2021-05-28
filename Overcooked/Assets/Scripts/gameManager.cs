using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelInstructions;
    public GameObject panelInstructions2;
    public GameObject panelCredits;
    public GameObject panelLevelComplete;

    public GameObject CompleteBurger;
    public GameObject CompleteFishBurger;
    public GameObject CompleteFishTomatoPotato;
    public GameObject Gazpacho;
    public GameObject MeatAndChips;
    public GameObject Panini;
    public GameObject TomatoMeatballs;

    public GameObject[] levels;

    public GameObject[] lvl1recipes;

    public GameObject[] lvl2recipes;

    public GameObject[] lvl3recipes;

    public GameObject[] lvl4recipes;

    public GameObject[] lvl5recipes;

    public static gameManager Instance { get; private set; }
    public enum State { MENU, LVLS, INST, INSTTWO, CREDITS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER, NEXT_RECIPE }
    State _state;
    GameObject _currentLevel;
    GameObject _currentRecipe;
    GameObject[] currentlvlrecipes;
    bool _isSwitching;

    private int _levels;
    private float cont;
    private int recipescont = 0;

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
        gameSounds.Instance.playButtonOn();
        changeState(State.INIT);
    }
    public void ClickInstructions()
    {
        gameSounds.Instance.playButtonOn();
        changeState(State.INST);
    }
    public void ClickInstructions2()
    {
        gameSounds.Instance.playButtonOn();
        changeState(State.INSTTWO);
    }
    public void ClickHome()
    {
        gameSounds.Instance.playButtonOn();
        changeState(State.MENU);
    }
    public void ClickCredits()
    {
        gameSounds.Instance.playButtonOn();
        changeState(State.CREDITS);
    }
    public void ClickExit()
    {
        gameSounds.Instance.playButtonOn();
        Application.Quit();
    }

    public bool checkRecipe(GameObject f)
    {
        if (f.name == _currentRecipe.name) return true;
        return false;
    }

    public void nextRecipe()
    {
        CurrentRecipes = Random.Range(0,currentlvlrecipes.Length);
        ++recipescont; 
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
                gameSounds.Instance.playTitleTheme();
                break;
            case State.LVLS:
                break;
            case State.INST:
                panelInstructions.SetActive(true);
                break;
            case State.INSTTWO:
                panelInstructions2.SetActive(true);
                break;
            case State.CREDITS:
                panelCredits.SetActive(true);
                break;
            case State.INIT:
                Levels = 0;
                CurrentRecipes = 0;
                currentlvlrecipes = lvl1recipes;
                panelPlay.SetActive(true);
                gameSounds.Instance.playGameTheme();
                _currentRecipe = Instantiate(lvl1recipes[Random.Range(0,currentlvlrecipes.Length)], panelPlay.transform);
                changeState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelComplete.SetActive(true);
                gameSounds.Instance.playEndingTheme();
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
                    CurrentRecipes = Random.Range(0,currentlvlrecipes.Length);
                    _currentLevel = Instantiate(levels[Levels]);
                    _currentRecipe = Instantiate(currentlvlrecipes[CurrentRecipes], panelPlay.transform);
                    changeState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if (_currentLevel != null) Destroy(_currentLevel);
                changeState(State.LEVELCOMPLETED);
                break;
            case State.NEXT_RECIPE:
                gameSounds.Instance.playDeliveryCompleteSound();
                if (recipescont >= currentlvlrecipes.Length)
                {
                    ++Levels;
                    if (Levels == 1) currentlvlrecipes = lvl2recipes;
                    if (Levels == 2) currentlvlrecipes = lvl3recipes;
                    if (Levels == 3) currentlvlrecipes = lvl4recipes;
                    if (Levels == 4) currentlvlrecipes = lvl5recipes;
                    recipescont = 0;
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
        if (Input.GetKey(KeyCode.Alpha1) && cont >= 0.5)
        {
            Levels = 0;
            currentlvlrecipes = lvl1recipes;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2) && cont >= 0.5)
        {
            Levels = 1;
            currentlvlrecipes = lvl2recipes;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Alpha3) && cont >= 0.5)
        {
            Levels = 2;
            currentlvlrecipes = lvl3recipes;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Alpha4) && cont >= 0.5)
        {
            Levels = 3;
            currentlvlrecipes = lvl4recipes;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Alpha5) && cont >= 0.5)
        {
            Levels = 4;
            currentlvlrecipes = lvl5recipes;
            changeState(State.LOADLEVEL);
            cont = 0;
        }
        if (Input.GetKey(KeyCode.R) && cont >= 0.5)
        {
            GameObject p = GameObject.FindWithTag("Player").gameObject;
            if (_currentRecipe.name == "MeatAndChips(Clone)")
            {
                GameObject food = Instantiate(MeatAndChips);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "CompleteBurger(Clone)")
            {
                GameObject food = Instantiate(CompleteBurger);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "CompleteFishBurger(Clone)")
            {
                GameObject food = Instantiate(CompleteFishBurger);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "CompleteFishTomatoPotato(Clone)")
            {
                GameObject food = Instantiate(CompleteFishTomatoPotato);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "Gazpacho(Clone)")
            {
                GameObject food = Instantiate(Gazpacho);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "Panini(Clone)")
            {
                GameObject food = Instantiate(Panini);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            if (_currentRecipe.name == "TomatoMeatballs(Clone)")
            {
                GameObject food = Instantiate(TomatoMeatballs);
                food.transform.position = p.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = p.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = p.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                p.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                p.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(p.gameObject);
            }
            cont = 0;
        }
        if (Input.GetKey(KeyCode.Escape) && cont >= 0.5)
        {
            if (_currentLevel != null) Destroy(_currentLevel);
            if (_currentRecipe != null) Destroy(_currentRecipe);
            changeState(State.MENU);
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
            case State.INSTTWO:
                panelInstructions2.SetActive(false);
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
