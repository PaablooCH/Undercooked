using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePan : MonoBehaviour
{

    public GameObject pan;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(pan, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), pan.transform.rotation);
        obj.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
