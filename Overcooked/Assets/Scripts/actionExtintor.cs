using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionExtintor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void throw_smoke()
    {
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }

    internal void stop_smoke()
    {
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
    }
}
