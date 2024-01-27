using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialFeature : MonoBehaviour
{
    private Vector3 offset; 
    private Vector3 Center = new(0, 0, 0); 
    private Tuple<int, float>[] closest = new Tuple<int, float>[5];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<5 && i<Face.Instance.spline.GetPointCount(); i++) 
            closest[i] = new(i, Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(i)));
        Array.Sort(closest);
        for(int i = 5; i<Face.Instance.spline.GetPointCount(); i++) {
            float dist = Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(i));
            if(closest[0].Item2 > dist) {
                closest[0] = new(i, dist);
                Array.Sort(closest);
            }
        }
        foreach(Tuple<int, float> i in closest) {
            Center += Face.Instance.spline.GetPosition(i.Item1)/5.0f;
        }
            
        offset =  Center - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Center = new(0, 0, 0);
        foreach(Tuple<int, float> i in closest) 
            Center += Face.Instance.spline.GetPosition(i.Item1)/5.0f;
        transform.position = Center - offset;
    }

    void OnDrawGizmos()
    {
        /*
        Gizmos.color = Color.red;
        for (int i = 0; i < 5; i++) {
            Gizmos.DrawSphere(Face.Instance.spline.GetPosition(closest[i].Item1), 0.1f);
        }
        Gizmos.DrawSphere(Center, 0.1f);
        */
    }
}
