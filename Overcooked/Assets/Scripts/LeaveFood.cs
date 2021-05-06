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
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
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
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                //Debug.Log("Primer if");
                GameObject com = obj.gameObject.GetComponent<MoveCharacter>().getFood();
                Debug.Log(com.name);
                if (com.name == "SlicedCheese(Clone)")
                {
                    Debug.Log("Segundo if");
                    GameObject a = food.GetComponent<combine>().combineWithCheese();
                    Destroy(food);
                    obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                    food = a;
                    food.transform.parent = this.transform.GetChild(0).transform;
                    food.GetComponent<pickUpFood>().enabled = false;
                    food.GetComponent<Rigidbody>().useGravity = false;
                    cont = 0;
                    onTable = false;
                    food = null;
                }
                /*if (com.name == "SlicedTomato(Clone)")
                {
                    Debug.Log("Segundo if");
                    GameObject a = food.GetComponent<combine>().combineWithCheese();
                    Destroy(food);
                    food = a;
                    obj.transform.position = this.transform.GetChild(0).position;
                    obj.transform.parent = this.transform.GetChild(0).transform;
                    obj.gameObject.GetComponent<MoveCharacter>().destroyFood();
                }*/

            }
        }
        else if (obj.tag == "Food" || obj.tag == "Cutted" || obj.tag == "Cooked" || obj.tag == "Blended" || obj.tag == "Combination" || obj.tag == "Complete")
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                //obj.GetComponent<BoxCollider>().enabled = true;
                //obj.GetComponent<Rigidbody>().useGravity = true;
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
