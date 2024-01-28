using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Face : MonoBehaviour
{
    public static Face Instance
    {
        get;
        private set;
    }
    public event Action HitPlayerEvent;
    public event Action NotHitPlayerEvent;
    public SpriteShapeController shapeController;
    public Spline spline;
    public float _punchRadius = 0.5f;
    public float hitForce;
    public float maxHitRange;
    public Vector3 Center = new(0, 0, 0);

    // Face Parts References
    public Spline mouthSpline;
    public GameObject nose, rightEar, leftEar, rightEye, leftEye, mouth;
    public float cooldown = 0.2f;
    public float counter = 0; 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        spline = shapeController.spline;
        Center = GetCenter(); 
    }

    public Vector3 GetCenter()
    {
        float sumx = 0, sumy = 0;
        for (int i = 0; i < spline.GetPointCount(); i++)
        {
            sumx += spline.GetPosition(i).x;
            sumy += spline.GetPosition(i).y;
        }
        return new Vector3(sumx / spline.GetPointCount(), sumy / spline.GetPointCount(), 0);
    }

    private bool CCW(Vector3 A, Vector3 B, Vector3 C) {
        return (C.y - A.y) * (B.x - A.x) > (B.y - A.y) * (C.x-A.x);
    }
    private bool Intersect(Vector3 A, Vector3 B, Vector3 C, Vector3 D){
        return CCW(A, C, D) != CCW(B, C, D) && CCW(A, B, C) != CCW(A, B, D);
    }

    private bool ValidShape(int ind, Vector3 newPoint) {
        Spline tempSpline = new();
        for(int i = 0; i<spline.GetPointCount(); i++) {
            if(i == ind) tempSpline.InsertPointAt(ind, newPoint);
            else tempSpline.InsertPointAt(i, spline.GetPosition(i));
        }
        for(int i = 1; i<tempSpline.GetPointCount(); i++) {
            for(int j = i+1; j<=tempSpline.GetPointCount(); j++){

                bool result = !Intersect(
                    tempSpline.GetPosition(i),
                    tempSpline.GetPosition(i-1),
                    tempSpline.GetPosition(j % tempSpline.GetPointCount()) + (tempSpline.GetPosition(j-1) - tempSpline.GetPosition(j % tempSpline.GetPointCount())).normalized * 0.01f,
                    tempSpline.GetPosition(j-1) - (tempSpline.GetPosition(j-1) - tempSpline.GetPosition(j % tempSpline.GetPointCount())).normalized * 0.01f
                );
                if(!result){ 
                    return false;
                }
            }
           
        }
        return true;
    }

    private void OnClickMouse(int direction)
    {
        bool hasHit = false;
        if (spline.GetPointCount() > 0)
        {
            Vector3 mousePosition = new(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0
            );

            // Busca el punto del spline mas cercano
            for (int i = 0; i < spline.GetPointCount(); i++)
            {
                Vector3 splinePoint = spline.GetPosition(i);
                float dist = Vector3.Distance(mousePosition, splinePoint);
                // Verificar que el punto del spline este deentro de punchradius
                if (dist < _punchRadius)
                {
                    hasHit = true;
                    Vector3 vectorAdd = (spline.GetPosition(i) - mousePosition).normalized;
                    Vector3 newPoint = splinePoint + hitForce * direction * vectorAdd;
                    if (newPoint.magnitude - GetCenter().magnitude > maxHitRange && ValidShape(i, newPoint))
                    {
                        spline.SetPosition(i, newPoint);
                    }
                } 
            }

            Center = GetCenter();
        } 
        
        if (hasHit) HitPlayerEvent?.Invoke();
        else NotHitPlayerEvent?.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0 && Input.GetMouseButtonDown(0)) {
            OnClickMouse(1);
            counter = cooldown;
        } 
        else if(counter > 0) counter -= Time.deltaTime;

    }

    void OnDrawGizmos()
    {
        Vector3 mousePosition = new(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
            0
        );
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(mousePosition, _punchRadius);
        
        for (int i = 0; i < spline.GetPointCount(); i++) {
            Gizmos.DrawSphere(spline.GetPosition(i), 0.1f);
            if(i > 0) {
                Gizmos.DrawLine(spline.GetPosition(i-1), spline.GetPosition(i));
            }
        }
        Gizmos.DrawSphere(Center, 0.1f);
    }
}
