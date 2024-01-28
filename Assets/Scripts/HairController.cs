using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    public Color[] hairColors; 
    private GameObject[] hair; 
    public Sprite[] hairTypes; 
    private int randomHairColor; 
    private int randomHairType;  
    private int bald; 
    private bool didItHappen = false; 
    // Start is called before the first frame update
    void Awake()
    {
        hair = GameObject.FindGameObjectsWithTag("Hair");
        randomHairColor = Random.Range(0, hairColors.Length - 1);
        randomHairType = Random.Range(0, hairTypes.Length -1);
        bald = Random.Range(0, 100);
        if(bald == 89){
            foreach (GameObject strand in hair){
                Destroy(strand);
            }
        }

        for(int i = 0; i < hair.Length && !didItHappen; i++){
            hair[i].GetComponent<SpriteRenderer>().color = hairColors[randomHairColor];
            hair[i].GetComponent<SpriteRenderer>().sprite = hairTypes[randomHairType];
        }
        
    }

}
