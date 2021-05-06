using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeLife : MonoBehaviour
{

    private float life;
    private float cont;
    // Start is called before the first frame update
    void Start()
    {
        life = 0;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        cont += Time.deltaTime;
        if(cont >= 0.025)
        {
            this.gameObject.transform.position += new Vector3(Random.value, Random.value, Random.value);
            cont = 0;
        }
        if (life >= 3) Destroy(this.gameObject);
    }
}
