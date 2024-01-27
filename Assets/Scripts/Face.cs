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
    public Vector3 Center = new(0, 0, 0);

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
                if (dist < _punchRadius)
                {
                     hasHit = true;
                    // Esta dentro de mi rango sumarle vector de la direccion del mouse
                    Vector3 vectorAdd = (spline.GetPosition(i) - mousePosition).normalized;
                    spline.SetPosition(i, splinePoint + hitForce * direction * vectorAdd);
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
        if (Input.GetMouseButtonDown(0)) OnClickMouse(1);
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
        /*
        for (int i = 0; i < spline.GetPointCount(); i++) {
            Gizmos.DrawSphere(spline.GetPosition(i), 0.1f);
        }
        Gizmos.DrawSphere(Center, 0.1f);
        */
    }
}
