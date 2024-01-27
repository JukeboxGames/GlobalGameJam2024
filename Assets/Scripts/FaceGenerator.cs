using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] facePrefabList;
    public GameObject selectedFace;

    private void Start() {
        selectedFace = facePrefabList[UnityEngine.Random.Range(0, facePrefabList.Length)];
    }
}
