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
                onTable = false;
                food = null;
                cont = 0;
            }
            //Debug.Log("Soy Player");
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
                onTable = true;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                food = obj.gameObject;
                cont = 0;
            }
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 2)
            {
                if(food.name == "SlicedBread")
                {
                    if(obj.name == "SlicedCheese")
                    {
                        GameObject a = food.gameObject.GetComponent<combine>().combine1();
                        Destroy(food);
                        food = a;
                        food.transform.position = this.transform.GetChild(0).position;
                        food.transform.parent = this.transform.GetChild(0).transform;
                        food.gameObject.GetComponent<pickUpFood>().changeState();
                        food.gameObject.GetComponent<pickUpFood>().resetCont();
                        cont = 0;
                        onTable = true;
                    }
                }
            }
            Debug.Log(obj.name);
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}
