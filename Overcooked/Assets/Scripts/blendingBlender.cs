using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendingBlender : MonoBehaviour
{
    private bool onTable;
    private GameObject food;
    private float cont;
    private bool finish;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
        cont = 0;
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;

        if (food != null && !finish && cont >= food.gameObject.GetComponent<convertInTo>().getCountBlend())
        {
            finish = true;
            GameObject a = food.GetComponent<convertInTo>().convertBlendfood();
            Destroy(food);
            food = a;
            food.transform.position = this.transform.GetChild(0).position;
            food.transform.parent = this.transform.GetChild(0).transform;
            food.GetComponent<pickUpFood>().changeState();
            food.GetComponent<pickUpFood>().resetCont();
            food.GetComponent<pickUpFood>().enabled = false;
            food.GetComponent<Rigidbody>().useGravity = false;
        }
        
        //Debug.Log(cont + food.name);
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.transform.position = obj.transform.GetChild(6).position;
                food.transform.eulerAngles = obj.transform.GetChild(6).eulerAngles;
                food.transform.parent = obj.transform.GetChild(6).transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                onTable = false;
                food = null;
                cont = 0;
                finish = false;
            }
            //Debug.Log("Soy Player");
        }
        else if (obj.tag == "Cutted" && obj.gameObject.GetComponent<convertInTo>().blendFood != null)
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.eulerAngles = this.transform.GetChild(0).eulerAngles;
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
