using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using UnityEngine.UI;

public class SwapCatScreen : MonoBehaviour
{
    public Sprite[] catImages;
    public ScoringSystem scorer;
    public Image rend; 

    private bool hasClicked = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasClicked = true;
        }

        if (!hasClicked)
        {
            rend.sprite = catImages[0];
        } else
        {
            if (scorer.GetScore() <= 40f)
            {
                rend.sprite = catImages[0];
            }
            if (scorer.GetScore() > 40f && scorer.GetScore() <= 50f)
            {
                rend.sprite = catImages[1];
            }
            if (scorer.GetScore() > 50f && scorer.GetScore() <= 60f)
            {
                rend.sprite = catImages[2];
            }
            if (scorer.GetScore() > 60f && scorer.GetScore() <= 75f)
            {
                rend.sprite = catImages[3];
            }
            if (scorer.GetScore() > 75f)
            {
                rend.sprite = catImages[4];
            }
        }

    }   
    
}
