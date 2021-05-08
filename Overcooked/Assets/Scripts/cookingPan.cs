using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookingPan : MonoBehaviour
{
    private bool onTable;
    private GameObject food;
    private float cont;
    private bool cooked;
    private bool burned;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
        cont = 0;
        cooked = false;
        burned = false;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if(food != null)
        {
            if (cont >= 6 && !burned)
            {
                burned = true;
                GameObject a = food.gameObject.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
                food.gameObject.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
            }
            else if (cont >= 2 && !cooked)
            {
                cooked = true;
                GameObject a = food.gameObject.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
                food.gameObject.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
            }
            //Debug.Log(cont + food.name);
        }
        

    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5)
            {
                food.transform.position = obj.transform.GetChild(6).position;
                food.transform.parent = obj.transform.GetChild(6).transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                onTable = false;
                food = null;
                cont = 0;
                cooked = false;
                burned = false;
            }
            Debug.Log("Soy Player");
        }
        else if (obj.tag == "Cutted" && obj.gameObject.GetComponent<convertInTo>().nextFood != null)
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
            Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}