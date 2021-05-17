using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaveTool : MonoBehaviour
{
    private bool onStand;
    private GameObject tool;
    private float cont;

    // Start is called before the first frame update
    void Start()
    {
        onStand = false;
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
            if (Input.GetKey(KeyCode.Space) && onStand && cont >= 1 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                Debug.Log(-obj.transform.rotation.eulerAngles);
                tool.transform.position = obj.transform.Find("ToPickUp").position;
                tool.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                tool.transform.parent = obj.transform.Find("ToPickUp").transform;
                tool.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(tool);
                tool.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                //obj.GetComponent<BoxCollider>().enabled = true;
                onStand = false;
                Debug.Log(tool.transform.rotation.eulerAngles);
                tool = null;
                cont = 0;
            }
        }
        else if (obj.tag == "Tool")
        {
            if (Input.GetKey(KeyCode.Space) && !onStand && cont >= 2)
            {
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.eulerAngles = -this.transform.eulerAngles;
                obj.transform.parent = this.transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                onStand = true;
                tool = obj.gameObject;
                cont = 0;
            }
        }
    }

    public void changeState()
    {
        if (onStand) onStand = false;
        else onStand = true;
    }
}
