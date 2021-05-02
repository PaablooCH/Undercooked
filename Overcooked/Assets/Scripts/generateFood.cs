using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood: MonoBehaviour
{
    public GameObject food;
    private float cont;
    private GameObject foodGenerated;
    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        foodGenerated = (GameObject) Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
        cont = 0;
        full = true;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        Debug.Log(foodGenerated.gameObject); 
        if (!full && cont >= 5)
        {
            foodGenerated = (GameObject)Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
            cont = 0;
            full = true;
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        if (Input.GetKey(KeyCode.Space) && full)
        {
            if (obj.tag == "Player")
            {
                foodGenerated = null;
                full = false;
                cont = 0;
            }
        }

    }
}
