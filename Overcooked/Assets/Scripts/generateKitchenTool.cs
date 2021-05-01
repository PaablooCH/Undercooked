using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateKitchenTool : MonoBehaviour
{

    public GameObject kitchenTool;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(kitchenTool, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), kitchenTool.transform.rotation);
        obj.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
