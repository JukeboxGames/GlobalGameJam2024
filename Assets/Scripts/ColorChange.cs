using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ColorChange : MonoBehaviour
{
    public Color targetColor1;
    public Color targetColor2;
    private float val = 0;
    public Slider slider;
    public ScoringSystem scoringSystem;
    public Image bg;
    public float sliderSpeed = 0.003f;
    public float colorSpeed = 0.01f; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (val < scoringSystem._score / 100.0f)
        {
            val += sliderSpeed;
            slider.value = val;
        }


        if (val < 0.5f)
        {
            bg.color = Color.Lerp(bg.color, targetColor1, colorSpeed);
        }
        else bg.color = Color.Lerp(bg.color, targetColor2, colorSpeed);

    }
}