using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using UnityEngine.UI;

public class SwapCatScreen : MonoBehaviour
{
    public Sprite[] catImages;
    public ScoringSystem scorer;
    private float score; 
    public Image rend; 
    private int index; 
     static int MapNumberToOutput(int x)
    {
        // Define the range size
        int rangeSize = 20;

        // Calculate the index of the range
        int rangeIndex = (int)Math.Ceiling((double)x / rangeSize);

        // Cap the range index to 5
        rangeIndex = Math.Min(rangeIndex, 5);

        return rangeIndex;
    }
    void Update(){
        score = scorer.GetScore();
        index = MapNumberToOutput((int)score);
        Console.WriteLine(index);
        if(index != 0){
            rend.sprite = catImages[index-1];
        }
    }
    
}
