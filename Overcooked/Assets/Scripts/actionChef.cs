using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionChef : MonoBehaviour
{
    private float cont;
    private bool sound = false;
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
                this.transform.Find("ToPickUp").gameObject.transform.GetChild(0).gameObject.GetComponent<actionExtintor>().throw_smoke();
                if(!sound)gameSounds.Instance.playExtinguisherSound();
                sound = true;
            }
            if (cont >= 0.25)
            {
                this.transform.Find("ToPickUp").gameObject.transform.GetChild(0).gameObject.GetComponent<actionExtintor>().stop_smoke();
                gameSounds.Instance.stopExtinguisherSound();
                sound = false;
            }
        }
        

    }
}
