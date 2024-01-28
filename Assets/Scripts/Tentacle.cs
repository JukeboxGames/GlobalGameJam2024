using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int length; 
    public LineRenderer lineRend; 
    public Vector3[] segmentPoses;

    public Transform targetDir; 
    public float targetDist;

    private Vector3[] segmentV; 

    public float smoothSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = length; 
        segmentPoses = new Vector3[length]; 
        
    }

    // Update is called once per frame
    void Update()
    {
        segmentPoses[0] = targetDir.position; 
        for(int i = 1; i < segmentPoses.Length; i++){
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}