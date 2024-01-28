using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHairForce : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         Vector3 mousePosition = new(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0
        );
        Vector3 vectorAdd = (transform.position - mousePosition).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(vectorAdd * m_Thrust);
        }
    }
}
