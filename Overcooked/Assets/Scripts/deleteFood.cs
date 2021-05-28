using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFood : MonoBehaviour
{
    GameObject food;
    float cont;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Food" || obj.tag == "Cutted" || obj.tag == "Cooked" || obj.tag == "Blended" || obj.tag == "Complete" || obj.tag == "Combination" || obj.tag == "NoDishFood" || obj.tag == "Oven")
        {
            if (Input.GetKey(KeyCode.Space) && cont >= 2)
            {
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                Destroy(obj.gameObject);
                cont = 0;
            }
        }
    }

}
