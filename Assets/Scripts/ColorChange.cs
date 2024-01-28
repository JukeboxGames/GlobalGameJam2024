using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ColorChange : MonoBehaviour
{
    public Color targetColor1;
    public Color targetColor2;
    public Slider slider;
    public ScoringSystem scoringSystem;
    public Image bg;
    public float sliderSpeed = 0.003f;
    public float colorSpeed = 0.01f; 
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100f;
    }

    // Update is called once per frame
    void Update()
    {    
        print(1); 
        slider.value = scoringSystem.GetScore();
        
        if (slider.value < 60f)
        {
            bg.color = Color.Lerp(bg.color, targetColor1, colorSpeed);
        }
        else bg.color = Color.Lerp(bg.color, targetColor2, colorSpeed);
    }
}
