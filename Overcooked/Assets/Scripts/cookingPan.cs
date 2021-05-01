using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookingPan : MonoBehaviour
{
    public Transform Dest;
    public GameObject cook1;
    public GameObject cook2;
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
        
            if (food.name == "SlicedMeat" && cont >= 2)
            {
                Destroy(food);
                food = (GameObject)Instantiate(cook1, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), cook1.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
                }
            if (cont >= 5)
            {
                Debug.Log("Soy Player");
                Destroy(food);
                food = (GameObject)Instantiate(cook2, transform.position + new Vector3(-0.06f, 1.0f, 0.05f), cook2.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
                }
            Debug.Log(cont + food.name);

    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5)
            {
                onTable = false;
                food = null;
                cont = 0;
            }
            //Debug.Log("Soy Player");
        }
        else if (obj.tag == "Food")
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                //obj.GetComponent<BoxCollider>().enabled = true;
                //obj.GetComponent<Rigidbody>().useGravity = true;
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.parent = this.transform.GetChild(0).transform;
                onTable = true;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                food = obj.gameObject;
                cont = 0;
            }
            //Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}