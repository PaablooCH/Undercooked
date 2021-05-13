using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood: MonoBehaviour
{
    public GameObject food;
    private GameObject generate;
    private float cont;
    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
        obj.transform.parent = transform;
        obj.GetComponent<pickUpFood>().enabled = false;
        generate = obj;
        full = true;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        //Debug.Log(foodGenerated.gameObject); 
        if (!full && cont >= 5)
        {
            GameObject obj = (GameObject)Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
            obj.transform.parent = transform;
            obj.GetComponent<pickUpFood>().enabled = false;
            generate = obj;
            cont = 0;
            full = true;
            Debug.Log("generar");
        }
        //if(this.name == "generatorCheese (1)")Debug.Log(this.name + ": " + full);
        //if(this.name == "generatorCheese (1)")Debug.Log(this.name + ": " + cont);
    }

    private void OnTriggerStay(Collider obj)
    {
        Debug.Log(obj.tag);
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && full && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                generate.transform.position = obj.transform.GetChild(6).position;
                generate.transform.parent = obj.transform.GetChild(6).transform;
                generate.GetComponent<pickUpFood>().enabled = true;
                generate.GetComponent<Rigidbody>().useGravity = false;
                generate.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                generate.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                full = false;
                cont = 0;
                generate = null;
                Debug.Log("Player");
            }
        }
    }
}