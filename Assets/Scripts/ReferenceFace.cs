using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ReferenceFace : MonoBehaviour
{
    public Spline faceSpline, mouthSpline;

    public GameObject nose, rightEar, leftEar, rightEye, leftEye, mouth;
    public Vector3 center;
    
    public SpriteShapeController shapeController;

    private void Awake() {
        faceSpline = shapeController.spline;
    }

    /*public void RandomizeFacialFeatures(){
        GameObject anchor = new GameObject("Anchor");
        GameObject anchorRef = Instantiate(anchor, transform.TransformPoint(transform.position), transform.rotation);
        Transform anchorTransf = anchorRef.transform;
        nose.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
        rightEar.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
        leftEar.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
        rightEye.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
        leftEye.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
        mouth.GetComponent<SwapPrefab>().SwapForReference(anchorTransf);
    }*/
}
