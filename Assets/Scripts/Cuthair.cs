using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuthair : MonoBehaviour
{
    private Rigidbody2D rb;
    void Awake(){
         rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Cut()
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found.");
            return;
        }

        if (rb.bodyType == RigidbodyType2D.Kinematic){
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        rb.gravityScale = 1f;
        SpringJoint2D[] joints = GetComponentsInChildren<SpringJoint2D>();
        Rigidbody2D[] rbS = GetComponentsInChildren<Rigidbody2D>();
        foreach (SpringJoint2D joint in joints){
            joint.enabled = false;
        }
        foreach(Rigidbody2D rigidB in rbS){
            rigidB.gravityScale = 1f; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && gameObject.GetComponent<ChildFeature>().OverMe && !Face.Instance.IsDisabled){
            Cut();
        }
    }
}
