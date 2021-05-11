using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateKitchenTool : MonoBehaviour
{
    public GameObject kitchenTool;

    // Start is called before the first frame update
    void Start()
    {
        if (kitchenTool.gameObject.name == "pan")
        {
            GameObject obj = (GameObject)Instantiate(kitchenTool, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), kitchenTool.transform.rotation);
            obj.transform.parent = transform;
        }
        else if (kitchenTool.gameObject.name == "blender")
        {
            GameObject obj = (GameObject)Instantiate(kitchenTool, transform.position + new Vector3(-0.06f, 0.6f, -0.1f), kitchenTool.transform.rotation);
            obj.transform.parent = transform;
        }
        else if (kitchenTool.gameObject.name == "Knife")
        {
            GameObject obj = (GameObject)Instantiate(kitchenTool, transform.position + new Vector3(-0.25f, 0.7f, 0.1f), kitchenTool.transform.rotation);
            obj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
