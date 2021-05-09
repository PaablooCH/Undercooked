using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convertInTo : MonoBehaviour
{
    public GameObject nextFood;

    public float countNext;

    public GameObject blendFood;

    public float countBlend;

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

    public float getCountNext()
    {
        return countNext;
    }

    public float getCountBlend()
    {
        return countBlend;
    }

    public GameObject convertBlendfood()
    {
        return (GameObject)Instantiate(blendFood, transform.position, blendFood.transform.rotation);
    }

}
