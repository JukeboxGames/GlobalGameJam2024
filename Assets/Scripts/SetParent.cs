using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private void Start() {
        if (parent != null) {
            gameObject.transform.SetParent(parent);
            gameObject.transform.localPosition = Vector3.zero;
        }      
    }
}
