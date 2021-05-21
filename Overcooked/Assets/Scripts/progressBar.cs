using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public Slider slide;

    private float FillProgress = 0.5f;
    private float TargetProgress = 0;
    private void Awake()
    {
        slide = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if(slide.value < TargetProgress)
        {
            slide.value += Time.deltaTime; 
        }
    }

    public void IncrementProgress(float newProgress)
    {
        TargetProgress = slide.value + newProgress;
    }

    public void StartCounter(float maxCont)
    {
        slide.value = 0;
        slide.maxValue = maxCont;
        IncrementProgress(maxCont);
    }
}
