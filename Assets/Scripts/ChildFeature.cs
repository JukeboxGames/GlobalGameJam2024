using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFeature : MonoBehaviour
{
    public bool OverMe = false; 
    
    void OnMouseOver(){
        OverMe = true; 
    }
    void OnMouseExit(){
        OverMe = false;
    }
}
