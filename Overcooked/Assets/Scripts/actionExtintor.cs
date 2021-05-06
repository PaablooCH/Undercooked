using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionExtintor : MonoBehaviour
{
    public GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void throw_smoke()
    {
        GameObject obj = (GameObject) Instantiate(smoke, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), smoke.transform.rotation);
        obj.transform.parent = transform;
    }

}
