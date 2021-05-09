using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood: MonoBehaviour
{
    public GameObject food;
    private float cont;
    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
        obj.transform.parent = transform;
        obj.GetComponent<pickUpFood>().enabled = false;
        food = obj;
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
            food = obj;
            cont = 0;
            full = true;
        }
    }

    private void OnCollisionStay(Collision obj)
    {
        if (Input.GetKey(KeyCode.Space) && full)
        {
            if (obj.collider.tag == "Player")
            {
                food.transform.position = obj.transform.GetChild(6).position;
                food.transform.parent = obj.transform.GetChild(6).transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                full = false;
                cont = 0;
            }
        }
    }

}