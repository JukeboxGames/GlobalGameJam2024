using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite cross;
    [SerializeField] private Sprite dot;
    [SerializeField] private Color crossColor;
    [SerializeField] private Color dotColor;

    private bool inHittableSpot;
    void Start()
    {
        Cursor.visible = false;
        spriteRenderer.sprite = cross;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
            0
        );
        if (SceneManager.GetActiveScene().name == "SampleScene" && Face.Instance.spline.GetPointCount() > 0)
        {
            inHittableSpot = false;
            // Busca el punto del spline mas cercano
            for (int i = 0; i < Face.Instance.spline.GetPointCount(); i++)
            {
                Vector3 splinePoint = Face.Instance.spline.GetPosition(i);
                float dist = Vector3.Distance(mousePosition, splinePoint);
                // Verificar que el punto del spline este deentro de punchradius
                if (dist < Face.Instance._punchRadius)
                {   
                    inHittableSpot = true;
                } 
            }

            if (inHittableSpot)
            {
                spriteRenderer.color = crossColor;
            } else{
                spriteRenderer.color = dotColor;
            }

            Face.Instance.Center = Face.Instance.GetCenter();
        } 

        transform.position = mousePosition;
    }
}
