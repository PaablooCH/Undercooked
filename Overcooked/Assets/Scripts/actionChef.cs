using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionChef : MonoBehaviour
{
    private float cont;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if(this.transform.Find("ToPickUp").gameObject.transform.childCount > 0 && this.transform.Find("ToPickUp").gameObject.transform.GetChild(0).gameObject.tag == "Tool")
        {
            if (Input.GetKey(KeyCode.F))
            {
                cont = 0;
                this.transform.Find("ToPickUp").gameObject.transform.GetChild(0).gameObject.GetComponent<actionExtintor>().throw_smoke(); //dependiendo cuantos tenga, hay que elegui el ToPickUp
            }
            if (cont >= 0.25) this.transform.Find("ToPickUp").gameObject.transform.GetChild(0).gameObject.GetComponent<actionExtintor>().stop_smoke(); //dependiendo cuantos tenga, hay que elegui el ToPickUp
        }
        

    }
}
