using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FaceChanger : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;
    Spline spline;
    [SerializeField] private Vector3 pos;
    [SerializeField] private float animationStep;

    private void Start() {
        
        spline = spriteShapeController.spline;
        Debug.Log(spline.GetPosition(0));
    }

    private void Update() {
        //spline.SetPosition(0,Vector3.Lerp(spline.GetPosition(0),pos,Time.deltaTime * animationStep));
    }
}
