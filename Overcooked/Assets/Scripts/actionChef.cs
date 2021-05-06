using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionChef : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.GetChild(6).gameObject.transform.childCount > 0 && Input.GetKey(KeyCode.F) && this.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.name == "fire extinguisher")
        {
            this.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<actionExtintor>().throw_smoke(); //dependiendo cuantos tenga, hay que elegui el ToPickUp
        }
            
    }
}
