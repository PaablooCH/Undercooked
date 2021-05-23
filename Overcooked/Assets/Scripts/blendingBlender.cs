using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blendingBlender : MonoBehaviour
{
    private bool onTable;
    private GameObject food;
    private float cont;
    private bool finish;
    public Slider progress;

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
            progress.gameObject.SetActive(false);
        }
        
        //Debug.Log(cont + food.name);
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.transform.position = obj.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = obj.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
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
                progress.gameObject.SetActive(true);
                progress.GetComponent<progressBar>().StartCounter(food.gameObject.GetComponent<convertInTo>().getCountBlend());
            }
            Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }

    public void finishProcess()
    {
        if (food != null)
        {
            cont = food.GetComponent<convertInTo>().getCountBlend();
        }
    }

}
