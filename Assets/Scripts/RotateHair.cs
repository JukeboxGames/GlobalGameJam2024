using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateHair : MonoBehaviour
{
    public float rotationSpeed; 
    private Vector3 direction; 
    private Tuple<int, float> closest = new(0,0);
    public Vector3 closestTransform; 

    void Start()
    {
        closest = new(0, Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(0)));
        for(int i = 0; i<Face.Instance.spline.GetPointCount(); i++) {
            float dist = Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(i));
            if(closest.Item2 > dist) {
                closest = new(i, dist);
            }
        }
    }

    void Update(){
        closestTransform = Face.Instance.spline.GetPosition(closest.Item1);
        direction = -closestTransform;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); 
    }
}
