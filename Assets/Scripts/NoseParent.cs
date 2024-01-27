using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseParent : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Center; 

    // Update is called once per frame
    void Update()
    {
        Center = Face.Instance.Center;
        transform.position = Center;
    }
}
