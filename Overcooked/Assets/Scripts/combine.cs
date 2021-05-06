using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combine : MonoBehaviour
{
    public GameObject combination1;

    public GameObject combination2;

    public GameObject combination3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject combine1()
    {
        return (GameObject)Instantiate(combination1, transform.position, combination1.transform.rotation);
    }
    public GameObject combine2()
    {
        return (GameObject)Instantiate(combination2, transform.position, combination2.transform.rotation);
    }
    public GameObject combine3()
    {
        return (GameObject)Instantiate(combination3, transform.position, combination3.transform.rotation);
    }
}
