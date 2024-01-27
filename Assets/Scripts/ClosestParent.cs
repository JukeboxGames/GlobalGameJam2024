using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClosestParent : MonoBehaviour
{
    public Tuple<int, float> closest = new(0,0);
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        transform.position = Face.Instance.spline.GetPosition(closest.Item1);
    }
}
