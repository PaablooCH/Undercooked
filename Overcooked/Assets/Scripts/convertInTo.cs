using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convertInTo : MonoBehaviour
{
    public GameObject nextFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject convertFood()
    {
       return (GameObject)Instantiate(nextFood, transform.position, nextFood.transform.rotation);
    }

}
