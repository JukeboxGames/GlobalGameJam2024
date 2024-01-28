using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesController : MonoBehaviour
{

    public GameObject[] allFaces; 
    private int index; 
    public GameObject facePlaceParent; 
    public ScoringSystem scorer; 
    // Start is called before the first frame update
    void Awake()
    {
        index = Random.Range(0, allFaces.Length);
        Instantiate(allFaces[index], facePlaceParent.transform); 
        scorer.SetTargetFace(allFaces[index].GetComponent<ReferenceFace>());
        //allFaces[index].GetComponent<ReferenceFace>().RandomizeFacialFeatures();
    }
}
