using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFood : MonoBehaviour
{
    private bool onTable;
    private GameObject food;
    private float cont;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 1 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.transform.position = obj.transform.GetChild(6).position;
                food.transform.parent = obj.transform.GetChild(6).transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                //obj.GetComponent<BoxCollider>().enabled = true;
                onTable = false;
                food = null;
                cont = 0;
            }
            else if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                GameObject com = obj.gameObject.GetComponent<MoveCharacter>().getFood();
                com.GetComponent<pickUpFood>().resetCont();
                if (com.name == "SlicedCheese(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCheese();
                    if(a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                    }
                    else Destroy(a);
                }
                if (com.name == "SlicedTomato(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithTomato();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "CookedBread(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithBread();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "SlicedBread(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCuttedBread();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "SlicedCucumber(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCucumber();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "CookedFish(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithFish();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "SlicedFish(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCuttedFish();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "CookedPotato(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithPotato();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "SlicedPotato(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCuttedPotato();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "CookedMeat(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithMeat();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "BlenderBread(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithBreadPics();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "BlenderCucumber(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithCucumberSauce();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
                if (com.name == "BlenderTomato(Clone)")
                {
                    GameObject a = food.GetComponent<combine>().combineWithTomatoSauce();
                    if (a != null)
                    {
                        Destroy(food);
                        obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                        food = a;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.GetComponent<pickUpFood>().enabled = false;
                        food.GetComponent<Rigidbody>().useGravity = false;
                        obj.gameObject.GetComponent<MoveCharacter>().changeHold(false);
                        cont = 0;
                        //onTable = false;
                        //food = null;
                    }
                    else Destroy(a);
                }
            }
        }
        else if (obj.tag == "Food" || obj.tag == "Cutted" || obj.tag == "Cooked" || obj.tag == "Blended" || obj.tag == "Combination" || obj.tag == "Complete")
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.parent = this.transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                onTable = true;
                food = obj.gameObject;
                cont = 0;
            }
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}
