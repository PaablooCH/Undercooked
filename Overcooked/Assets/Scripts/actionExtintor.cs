using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionExtintor : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = this.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void throw_smoke()
    {
        ps.Play();
    }

    internal void stop_smoke()
    {
        ps.Stop();
    }

}
