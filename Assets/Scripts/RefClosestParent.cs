using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.U2D;

public class RefClosestParent : MonoBehaviour
{
    public Tuple<int, float> closest = new(0,0);
    [SerializeField] private Vector3 offset;
    [SerializeField] private SpriteShapeController shapeController;
    private Spline spline;
    
    // Start is called before the first frame update
    void Start()
    {
        spline = shapeController.spline;
        closest = new(0, Vector3.Distance(transform.position, spline.GetPosition(0)));
        for(int i = 0; i<spline.GetPointCount(); i++) {
            float dist = Vector3.Distance(transform.position, spline.GetPosition(i));
            if(closest.Item2 > dist) {
                closest = new(i, dist);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spline.GetPosition(closest.Item1) + offset;
    }
}
