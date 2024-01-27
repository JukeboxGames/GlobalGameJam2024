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
}
