using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood: MonoBehaviour
{

    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
        obj.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
